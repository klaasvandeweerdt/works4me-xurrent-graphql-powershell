using System;
using System.Management.Automation;
using System.Text.Json;
using Works4me.Xurrent.GraphQL.Extensions;
using Works4me.Xurrent.GraphQL.PowerShell.Enums;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Gets a value from a <see cref="CustomFieldCollection"/> by its identifier and optionally converts it to a specific type.<br/>
    /// This cmdlet is useful for extracting values from UI Extension custom fields in a strongly typed manner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "XurrentCustomField")]
    [OutputType(typeof(object))]
    public sealed class GetXurrentCustomField : XurrentCmdletBase
    {
        /// <summary>
        /// The <see cref="CustomFieldCollection"/> to retrieve the value from.<br/>
        /// This collection is typically obtained from a GraphQL response and contains the values of filterable or extended fields.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public CustomFieldCollection Collection { get; set; } = null!;

        /// <summary>
        /// The identifier of the custom field to retrieve.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Specifies how the retrieved value should be returned.<br/>
        /// Defaults to <see cref="XurrentCustomFieldAs.Raw"/> to return the underlying JSON element.<br/>
        /// Use another <see cref="XurrentCustomFieldAs"/> value to convert the field to a specific .NET type (e.g., <c>String</c>, <c>Int32</c>, <c>DateTime</c>).
        /// </summary>
        [Parameter(Position = 2)]
        public XurrentCustomFieldAs As { get; set; } = XurrentCustomFieldAs.Raw;

        /// <summary>
        /// Processes the input <see cref="CustomFieldCollection"/> and writes the value of the specified custom field to the pipeline.<br/>
        /// If <see cref="As"/> is <see cref="XurrentCustomFieldAs.Raw"/>, the raw <see cref="System.Text.Json.JsonElement"/> is returned.<br/>
        /// Otherwise, the value is converted to the requested type.<br/>
        /// A terminating error is thrown if the field cannot be converted to the requested type.
        /// </summary>
        protected override void OnProcessRecord()
        {
            JsonElement? elementNullable = Collection[Id];

            if (elementNullable is null)
            {
                WriteObject(null);
                return;
            }

            if (elementNullable.Value.ValueKind == JsonValueKind.Null || elementNullable.Value.ValueKind == JsonValueKind.Undefined)
            {
                if (As == XurrentCustomFieldAs.Raw)
                {
                    JsonElement rawNull = elementNullable.Value;
                    WriteObject(rawNull, false);
                }
                else
                {
                    WriteObject(null, false);
                }
                return;
            }

            if (As == XurrentCustomFieldAs.Raw)
            {
                JsonElement raw = elementNullable.Value;
                WriteObject(raw, false);
                return;
            }

            if (As == XurrentCustomFieldAs.JsonString)
            {
                JsonElement raw = elementNullable.Value;
                WriteObject(raw.GetRawText(), false);
                return;
            }

            try
            {
                switch (As)
                {
                    case XurrentCustomFieldAs.String:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<string?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<string?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Char:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<char?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<char?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Boolean:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<bool?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<bool?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Int16:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<short?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<short?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Int32:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<int?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<int?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Int64:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<long?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<long?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.SByte:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<sbyte?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<sbyte?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.UInt16:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<ushort?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<ushort?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.UInt32:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<uint?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<uint?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.UInt64:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<ulong?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<ulong?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Byte:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<byte?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<byte?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Single:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<float?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<float?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Double:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<double?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<double?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.Decimal:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<decimal?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<decimal?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.DateTime:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<DateTime?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<DateTime?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.DateTimeOffset:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<DateTimeOffset?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<DateTimeOffset?>(), false);
                            return;
                        }
#if NET6_0_OR_GREATER
                    case XurrentCustomFieldAs.DateOnly:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<DateOnly?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<DateOnly?>(), false);
                            return;
                        }
                    case XurrentCustomFieldAs.TimeOnly:
                        {
                            if (elementNullable.Value.ValueKind == JsonValueKind.Array)
                                WriteObject(elementNullable.GetValue<TimeOnly?[]>(), true);
                            else
                                WriteObject(elementNullable.GetValue<TimeOnly?>(), false);
                            return;
                        }
#endif
                    default:
                        ThrowTerminatingError(new ErrorRecord(new InvalidOperationException("Unknown -As value."), "UnknownAs", ErrorCategory.InvalidArgument, As));
                        return;
                }
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(new InvalidOperationException($"Cannot convert JSON {elementNullable.Value.ValueKind} to {As}.", ex), "XurrentCustomFieldConversion", ErrorCategory.InvalidData, Id));
            }
        }
    }
}