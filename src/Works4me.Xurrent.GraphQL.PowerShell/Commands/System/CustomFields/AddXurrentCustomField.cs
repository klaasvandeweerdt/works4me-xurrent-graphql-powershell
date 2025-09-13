using System;
using System.Management.Automation;
using System.Text.Json;
using Works4me.Xurrent.GraphQL.PowerShell.Utilities;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Adds or updates a value in a <see cref="CustomFieldCollection"/>.<br/>
    /// Supports two parameter sets: <c>Object</c> (converts a PowerShell object via <see cref="JsonElementCoercion"/>)
    /// and <c>Json</c> (parses a raw JSON string).<br/>
    /// Uses PowerShell confirmation semantics (<c>-WhatIf</c>/<c>-Confirm</c>) and returns the updated collection.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "XurrentCustomField", DefaultParameterSetName = ParamSetObject, SupportsShouldProcess = true)]
    [OutputType(typeof(CustomFieldCollection))]
    public sealed class AddXurrentCustomField : XurrentCmdletBase
    {
        private const string ParamSetObject = "Object";
        private const string ParamSetJson = "Json";

        /// <summary>
        /// The target <see cref="CustomFieldCollection"/> to modify. Accepts input from the pipeline and may be empty.<br/>
        /// The specified <see cref="Id"/> will be added or updated in this collection.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public CustomFieldCollection Collection { get; set; } = null!;

        /// <summary>
        /// The custom field identifier to add or update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The custom field value to store, provided as a native PowerShell object.<br/>
        /// Converted to <see cref="JsonElement"/>.<br/>
        /// Use this in the <c>Object</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParamSetObject)]
        public object? Value { get; set; }

        /// <summary>
        /// The custom field value to store, provided as a raw JSON string.<br/>
        /// Parsed directly to <see cref="JsonElement"/>.<br/>
        /// Use this in the <c>Json</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParamSetJson)]
        [ValidateNotNullOrEmpty]
        public string JsonValue { get; set; } = string.Empty;

        /// <summary>
        /// Performs the add/update operation on the target <see cref="CustomFieldCollection"/>.<br/>
        /// Honors PowerShell confirmation (<c>-WhatIf</c>/<c>-Confirm</c>). Based on the active parameter set, converts
        /// <see cref="Value"/> or parses <see cref="JsonValue"/> to a <see cref="JsonElement"/> and assigns it to <c>Collection[Id]</c>.<br/>
        /// Writes the updated collection to the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            if (!ShouldProcess($"CustomFieldCollection[{Id}]", "Add or update custom field"))
                return;

            JsonElement? element = ParameterSetName switch
            {
                ParamSetObject => JsonElementCoercion.ToJsonElementOrNull(Value),
                ParamSetJson => ParseJson(JsonValue),
                _ => throw new InvalidOperationException("Unknown parameter set.")
            };

            Collection[Id] = element;
            WriteObject(Collection, false);
        }

        /// <summary>
        /// Parses a raw JSON string to a <see cref="JsonElement"/>.<br/>
        /// Throws an <see cref="ArgumentException"/> if the input is null/empty or not valid JSON.
        /// </summary>
        /// <param name="json">A valid JSON string.</param>
        /// <returns>A cloned <see cref="JsonElement"/> representing the JSON.</returns>
        /// <exception cref="ArgumentException">Thrown when the input is null/empty or invalid JSON.</exception>

        private static JsonElement ParseJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JsonValue cannot be null or empty.", nameof(json));

            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                return doc.RootElement.Clone();
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Invalid JSON provided to -JsonValue.", nameof(json), ex);
            }
        }
    }
}
