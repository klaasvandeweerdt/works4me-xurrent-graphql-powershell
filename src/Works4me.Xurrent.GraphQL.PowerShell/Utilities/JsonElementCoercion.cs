using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text.Json;
using Works4me.Xurrent.GraphQL.Extensions;

namespace Works4me.Xurrent.GraphQL.PowerShell.Utilities
{
    /// <summary>
    /// Converts dynamically-typed PowerShell inputs into <see cref="JsonElement"/> values.
    /// </summary>
    internal static class JsonElementCoercion
    {
        /// <summary>
        /// Converts the supplied value to a <see cref="JsonElement"/> or returns <c>null</c> for <c>$null</c>.
        /// </summary>
        /// <param name="value">An arbitrary PowerShell object (may be null).</param>
        /// <returns>A <see cref="JsonElement"/> representing the input, or <c>null</c> if <paramref name="value"/> is <c>null</c>.</returns>
        public static JsonElement? ToJsonElementOrNull(object? value)
        {
            if (value is null)
                return null;

            if (value is JsonElement je)
                return je;

            if (value is JsonDocument jd)
                return jd.RootElement.Clone();

            object normalized = Normalize(value);

            return normalized switch
            {
                string v => v.ToJsonElement(),
                char v => v.ToJsonElement(),
                bool v => v.ToJsonElement(),
                byte v => v.ToJsonElement(),
                sbyte v => v.ToJsonElement(),
                short v => v.ToJsonElement(),
                ushort v => v.ToJsonElement(),
                int v => v.ToJsonElement(),
                uint v => v.ToJsonElement(),
                long v => v.ToJsonElement(),
                ulong v => v.ToJsonElement(),
                float v => v.ToJsonElement(),
                double v => v.ToJsonElement(),
                decimal v => v.ToJsonElement(),
                DateTime v => v.ToJsonElement(),
                DateTimeOffset v => v.ToJsonElement(),
#if NET6_0_OR_GREATER
                DateOnly v => v.ToJsonElement(),
                TimeOnly v => v.ToJsonElement(),
#endif
                JsonElement v => v,
                JsonDocument v => v.RootElement.Clone(),
                _ => normalized.ToJsonElement()
            };
        }

        /// <summary>
        /// Recursively normalizes PowerShell objects into a POCO/primitives graph:<br />
        /// • Unwraps PSObject to BaseObject<br />
        /// • Materializes PSCustomObject note properties to a dictionary<br />
        /// • Normalizes IDictionary and IEnumerable<br />
        /// </summary>
        private static object Normalize(object value)
        {
            if (value is PSObject pso)
            {
                object baseObj = pso.BaseObject;
                if (baseObj is PSCustomObject)
                    return PSObjectToDictionary(pso);
                return Normalize(baseObj);
            }

            if (value is IDictionary dict)
            {
                Dictionary<string, object?> result = new(StringComparer.OrdinalIgnoreCase);
                foreach (DictionaryEntry entry in dict)
                {
                    string key = entry.Key?.ToString() ?? string.Empty;
                    result[key] = entry.Value is null ? null : Normalize(entry.Value);
                }
                return result;
            }

            if (value is IEnumerable seq && value is not string)
            {
                List<object?> list = new();
                foreach (object? item in seq)
                    list.Add(item is null ? null : Normalize(item));
                return list;
            }

            return value;
        }

        /// <summary>
        /// Extracts note properties from a PSCustomObject into a plain dictionary (avoids cyclical Members graph).
        /// </summary>
        private static Dictionary<string, object?> PSObjectToDictionary(PSObject pso)
        {
            Dictionary<string, object?> result = new(StringComparer.OrdinalIgnoreCase);
            foreach (PSPropertyInfo prop in pso.Properties)
            {
                if (prop.MemberType == PSMemberTypes.NoteProperty && prop.IsGettable)
                    result[prop.Name] = prop.Value is null ? null : Normalize(prop.Value);
            }
            return result;
        }
    }
}
