namespace Works4me.Xurrent.GraphQL.PowerShell.Filters
{
    /// <summary>
    /// Represents a custom, UI-extension based filter that can be applied to a query.<br/>
    /// Supports text comparisons and presence/emptiness checks depending on the selected operator.<br/>
    /// </summary>
    public sealed class CustomFilter
    {
        /// <summary>
        /// The name of the custom field to filter on (as defined in the UI Extension).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The comparison operator to apply to the custom field.<br/>
        /// Supported operators are <see cref="FilterOperator.Equals"/>, <see cref="FilterOperator.NotEquals"/>, <see cref="FilterOperator.Present"/>, and <see cref="FilterOperator.Empty"/>.
        /// </summary>
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// One or more text values used by operators that require a value.
        /// </summary>
        public string?[]? TextValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFilter"/> class.
        /// </summary>
        /// <param name="name">The custom field name to filter on.</param>
        /// <param name="operator">The filter operator to apply.</param>
        /// <param name="textValues">Optional text values used by value-based operators.</param>
        public CustomFilter(string name, FilterOperator @operator, string?[]? textValues)
        {
            Name = name;
            Operator = @operator;
            TextValues = textValues;
        }

        /// <summary>
        /// Validates the filter configuration for the selected operator and provided values.
        /// </summary>
        /// <param name="errorMessage">When validation fails, contains a human-readable explanation of the issue; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if the configuration is valid; otherwise <c>false</c>.</returns>
        public bool IsValid(out string? errorMessage)
        { 
            errorMessage = null;

            if (Operator == FilterOperator.Present || Operator == FilterOperator.Empty)
                return true;

            if (TextValues is not null && TextValues.Length > 0)
            {
                if (Operator == FilterOperator.Equals || Operator == FilterOperator.NotEquals)
                    return true;

                errorMessage = $"Unsupported custom filter operator. Supported operators include " +
                        $"{nameof(FilterOperator.Equals)}, {nameof(FilterOperator.NotEquals)}, " +
                        $"{nameof(FilterOperator.Present)}, and {nameof(FilterOperator.Empty)}.";

                return false;
            }

            errorMessage = $"Unsupported custom filter, use the filter operator {nameof(FilterOperator.Present)} or {nameof(FilterOperator.Empty)}, or provide the {nameof(TextValues)}.";
            return false;
        }
    }
}
