using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="CustomFilter"/> object for use in Xurrent queries.<br/>
    /// A custom filter allows filtering on fields defined in a UI Extension that are marked as "Filterable".<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentCustomFilter", DefaultParameterSetName = NoneSet)]
    [OutputType(typeof(CustomFilter))]
    public class NewXurrentCustomFilter : XurrentCmdletBase
    {
        private const string NoneSet = "None";
        private const string TextSet = "Text";

        /// <summary>
        /// The name of the custom field to filter on, as defined in the UI Extension.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The operator to apply to the custom field.
        /// Supported operators include <see cref="FilterOperator.Equals"/>, <see cref="FilterOperator.NotEquals"/>, <see cref="FilterOperator.Present"/>, and <see cref="FilterOperator.Empty"/>.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// One or more text values used when applying a value-based operator.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = TextSet)]
        public string?[]? TextValues { get; set; }

        /// <summary>
        /// Validates the filter configuration and writes a <see cref="CustomFilter"/> object to the pipeline when valid.<br/>
        /// If the configuration is invalid, a terminating error is thrown with a descriptive message.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CustomFilter customFilter = new(Name, Operator, TextValues);

            if (TextValues is null && (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals))
                customFilter.TextValues = new string?[] { null };

            if (customFilter.IsValid(out string? errorMessage))
            {
                WriteObject(customFilter, false);
            }
            else
            {
                ThrowTerminatingError(new ErrorRecord(new XurrentQueryException(errorMessage!), "InvalidCustomFilter", ErrorCategory.NotSpecified, this));
            }
        }
    }
}
