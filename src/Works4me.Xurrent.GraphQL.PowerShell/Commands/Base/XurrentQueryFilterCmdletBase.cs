using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Base class for <c>*QueryFilter</c> cmdlets.<br/>
    /// Constructs a <see cref="QueryFilter{TEntity}"/> from the provided fields, then writes it to the pipeline.<br/>
    /// </summary>
    /// <typeparam name="TEntity">
    /// The enumeration that identifies filterable fields of the target entity.
    /// </typeparam>
    public class XurrentQueryFilterCmdletBase<TEntity> : XurrentCmdletBase where TEntity : notnull, Enum
    {
        private const string TextSet = "Text";
        private const string DateTimeSet = "DateTime";
        private const string BoolSet = "Boolean";
        private const string IntSet = "Integer";

        /// <summary>
        /// The field to filter on. Must be a valid <typeparamref name="TEntity"/> member.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TEntity Property { get; set; } = default!;

        /// <summary>
        /// The comparison operator to apply to <see cref="Property"/>.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Boolean value for boolean operators.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = BoolSet)]
        public bool? BooleanValue { get; set; }

        /// <summary>
        /// One or more date/time values for date/time operators.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = DateTimeSet)]
        public DateTime?[]? DateTimeValues { get; set; }

        /// <summary>
        /// One or more integer values for integer operators.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = IntSet)]
        public int?[]? IntegerValues { get; set; }

        /// <summary>
        /// One or more text values for string operators.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = TextSet)]
        public string?[]? TextValues { get; set; }

        /// <summary>
        /// Validates the filter configuration and writes a <see cref="QueryFilter{TEntity}"/> to the pipeline when valid; otherwise throws a terminating error.
        /// </summary>
        /// <exception cref="XurrentQueryException"> Thrown (as a terminating error) when the combination of <see cref="Property"/>, <see cref="Operator"/>, and provided values is invalid for the target field/operator.</exception>
        protected override void OnProcessRecord()
        {
            QueryFilter<TEntity> queryFilter = new(Property, Operator)
            {
                DateTimeValues = DateTimeValues,
                BooleanValue = BooleanValue,
                IntegerValues = IntegerValues,
                TextValues = TextValues
            };

            if (queryFilter.IsValid(out string? errorMessage))
            {
                WriteObject(queryFilter);
            }
            else
            {
                ThrowTerminatingError(new ErrorRecord(new XurrentQueryException(errorMessage!), "InvalidQueryFilter", ErrorCategory.NotSpecified, this));
            }
        }
    }
}
