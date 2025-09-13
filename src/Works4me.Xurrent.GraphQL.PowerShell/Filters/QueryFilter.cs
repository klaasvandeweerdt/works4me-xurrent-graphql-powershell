using System;

namespace Works4me.Xurrent.GraphQL.PowerShell.Filters
{
    /// <summary>
    /// Represents a strongly typed filter that can be applied to a query.<br/>
    /// Supports filtering on boolean, date/time, integer, and text values depending on the operator.<br/>
    /// </summary>
    /// <typeparam name="TEntity">
    /// An enumeration that identifies the filterable fields of the target entity.
    /// </typeparam>
    public sealed class QueryFilter<TEntity> where TEntity : Enum
    {
        /// <summary>
        /// The entity property to filter on, represented by <typeparamref name="TEntity"/>.
        /// </summary>
        public TEntity Property { get; set; }

        /// <summary>
        /// The filter operator to apply to <see cref="Property"/>.
        /// The supported operators depend on the type of the provided value.
        /// </summary>
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Boolean value to use with boolean operators.
        /// </summary>
        public bool? BooleanValue { get; set; }

        /// <summary>
        /// One or more date/time values for operators that support temporal comparisons.
        /// </summary>
        public DateTime?[]? DateTimeValues { get; set; }

        /// <summary>
        /// One or more integer values for operators that support numeric comparisons.
        /// </summary>
        public int?[]? IntegerValues { get; set; }

        /// <summary>
        /// One or more text values for operators that support string comparisons.
        /// </summary>
        public string?[]? TextValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryFilter{TEntity}"/> class.
        /// </summary>
        /// <param name="property">The property to filter on.</param>
        /// <param name="operator">The filter operator to apply.</param>
        public QueryFilter(TEntity property, FilterOperator @operator)
        {
            Property = property;
            Operator = @operator;
        }

        /// <summary>
        /// Validates that the filter configuration is consistent with the provided values and operator.
        /// </summary>
        /// <param name="errorMessage">When the filter is invalid, contains a description of the reason; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if the filter configuration is valid; otherwise <c>false</c>.</returns>
        public bool IsValid(out string? errorMessage)
        {
            errorMessage = null;

            if (BooleanValue is not null)
            {
                if (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals)
                    return true;

                errorMessage = $"Unsupported boolean filter operator for '{Property}'. " +
                        $"Supported operators are {nameof(FilterOperator.Equals)} and {nameof(FilterOperator.NotEquals)}.";

                return false;
            }
           
            if (DateTimeValues is not null && DateTimeValues.Length > 0)
            {
                if (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals)
                    return true;

                if ((Operator == FilterOperator.LessThan || Operator == FilterOperator.LessThanOrEqualsTo || Operator == FilterOperator.GreaterThan || Operator == FilterOperator.GreaterThanOrEqualsTo) && DateTimeValues.Length == 1)
                    return true;

                if ((Operator == FilterOperator.GreaterThanAndLessThan || Operator == FilterOperator.GreaterThanOrEqualToAndLessThanOrEqualTo) && DateTimeValues.Length == 2)
                    return true;

                errorMessage = $"Unsupported date time filter operator for '{Property}'. " +
                    $"Use {nameof(FilterOperator.Equals)} or {nameof(FilterOperator.NotEquals)} with one or multiple values; " +
                    $"use {nameof(FilterOperator.LessThan)}, {nameof(FilterOperator.LessThanOrEqualsTo)}, " +
                    $"{nameof(FilterOperator.GreaterThan)}, or {nameof(FilterOperator.GreaterThanOrEqualsTo)} with a single value; " +
                    $"and use {nameof(FilterOperator.GreaterThanAndLessThan)} or " +
                    $"{nameof(FilterOperator.GreaterThanOrEqualToAndLessThanOrEqualTo)} with two values.";

                return false;
            }

            if (IntegerValues is not null && IntegerValues.Length > 0)
            {
                if (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals)
                    return true;

                if ((Operator == FilterOperator.LessThan || Operator == FilterOperator.LessThanOrEqualsTo || Operator == FilterOperator.GreaterThan || Operator == FilterOperator.GreaterThanOrEqualsTo) && IntegerValues.Length == 1)
                    return true;

                if ((Operator == FilterOperator.GreaterThanAndLessThan || Operator == FilterOperator.GreaterThanOrEqualToAndLessThanOrEqualTo) && IntegerValues.Length == 2)
                    return true;

                errorMessage = $"Unsupported integer filter operator for '{Property}'. " +
                    $"Use {nameof(FilterOperator.Equals)} or {nameof(FilterOperator.NotEquals)} with one or multiple values; " +
                    $"use {nameof(FilterOperator.LessThan)}, {nameof(FilterOperator.LessThanOrEqualsTo)}, " +
                    $"{nameof(FilterOperator.GreaterThan)}, or {nameof(FilterOperator.GreaterThanOrEqualsTo)} with a single value; " +
                    $"and use {nameof(FilterOperator.GreaterThanAndLessThan)} or " +
                    $"{nameof(FilterOperator.GreaterThanOrEqualToAndLessThanOrEqualTo)} with two values.";

                return false;
            }

            if (TextValues is not null && TextValues.Length > 0)
            {
                if (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals)
                    return true;

                errorMessage = $"Unsupported string filter operator for '{Property}'. Supported operators include " +
                        $"{nameof(FilterOperator.Equals)}, {nameof(FilterOperator.NotEquals)}, " +
                        $"{nameof(FilterOperator.Present)}, and {nameof(FilterOperator.Empty)}.";

                return false;
            }

            if (Operator == FilterOperator.Present || Operator == FilterOperator.Empty)
            {
                return true;
            }

            errorMessage = $"Unsupported filter, use the filter operator {nameof(FilterOperator.Present)} or {nameof(FilterOperator.Empty)}, or provide the {nameof(BooleanValue)}, {nameof(DateTimeValues)}, {nameof(IntegerValues)} or {nameof(TextValues)}.";
            return false;
        }
    }
}
