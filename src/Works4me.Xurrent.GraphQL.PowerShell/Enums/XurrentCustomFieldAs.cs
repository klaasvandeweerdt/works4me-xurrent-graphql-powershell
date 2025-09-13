namespace Works4me.Xurrent.GraphQL.PowerShell.Enums
{
    /// <summary>
    /// Specifies the target .NET type returned by <c>Get-XurrentCustomField</c> via the <c>-As</c> parameter.
    /// </summary>
    public enum XurrentCustomFieldAs
    {
        /// <summary>
        /// Returns the underlying <see cref="System.Text.Json.JsonElement"/> unchanged.
        /// Use this to inspect <see cref="System.Text.Json.JsonElement.ValueKind"/> or call <c>GetRawText()</c>.
        /// </summary>
        Raw,

        /// <summary>
        /// Returns the JSON string value as a JSON string.
        /// </summary>
        JsonString,

        /// <summary>
        /// Returns the JSON string value as a <see cref="string"/>. Requires a JSON String token.
        /// </summary>
        String,

        /// <summary>
        /// Returns the first character of the JSON string as a <see cref="char"/>. Requires a non-empty JSON String token.
        /// </summary>
        Char,

        /// <summary>
        /// Returns a <see cref="bool"/> from a JSON true/false token.
        /// </summary>
        Boolean,

        /// <summary>
        /// Returns an <see cref="short"/> from a JSON Number token within the <see cref="short"/> range.
        /// </summary>
        Int16,

        /// <summary>
        /// Returns an <see cref="int"/> from a JSON Number token within the <see cref="int"/> range.
        /// </summary>
        Int32,

        /// <summary>
        /// Returns a <see cref="long"/> from a JSON Number token within the <see cref="long"/> range.
        /// </summary>
        Int64,

        /// <summary>
        /// Returns an <see cref="sbyte"/> from a JSON Number token within the <see cref="sbyte"/> range.
        /// </summary>
        SByte,

        /// <summary>
        /// Returns a <see cref="ushort"/> from a JSON Number token within the <see cref="ushort"/> range.
        /// </summary>
        UInt16,

        /// <summary>
        /// Returns a <see cref="uint"/> from a JSON Number token within the <see cref="uint"/> range.
        /// </summary>
        UInt32,

        /// <summary>
        /// Returns a <see cref="ulong"/> from a JSON Number token within the <see cref="ulong"/> range.
        /// </summary>
        UInt64,

        /// <summary>
        /// Returns a <see cref="byte"/> from a JSON Number token within the <see cref="byte"/> range.
        /// </summary>
        Byte,

        /// <summary>
        /// Returns a <see cref="float"/> from a JSON Number token.
        /// </summary>
        Single,

        /// <summary>
        /// Returns a <see cref="double"/> from a JSON Number token.
        /// </summary>
        Double,

        /// <summary>
        /// Returns a <see cref="decimal"/> from a JSON Number token.
        /// </summary>
        Decimal,

        /// <summary>
        /// Returns a <see cref="System.DateTime"/> parsed from a JSON String in the format produced by your <c>ToJsonElement(DateTime)</c>
        /// (ISO-8601, invariant culture).
        /// </summary>
        DateTime,

        /// <summary>
        /// Returns a <see cref="System.DateTimeOffset"/> parsed from a JSON String in the format produced by your <c>ToJsonElement(DateTimeOffset)</c>
        /// (ISO-8601, invariant culture).
        /// </summary>
        DateTimeOffset,

#if NET6_0_OR_GREATER
    /// <summary>
    /// Returns a <see cref="System.DateOnly"/> parsed from a JSON String in <c>yyyy-MM-dd</c> format.
    /// </summary>
    DateOnly,

    /// <summary>
    /// Returns a <see cref="System.TimeOnly"/> parsed from a JSON String in <c>HH:mm:ss</c> format.
    /// </summary>
    TimeOnly
#endif
    }

}
