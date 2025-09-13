using Microsoft.Extensions.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// A logger provider that creates <see cref="PowerShellLogger"/> instances which write log messages to PowerShell streams.
    /// </summary>
    /// <remarks>
    /// This provider is used to integrate the <see cref="Microsoft.Extensions.Logging"/>  infrastructure with PowerShell, allowing log messages to be routed into PowerShell’s Information, Verbose, Warning, Error, or Debug streams.
    /// </remarks>
    internal sealed class PowerShellLoggerProvider : ILoggerProvider
    {
        private readonly PowerShellLoggerOptions _baseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellLoggerProvider"/> class.
        /// </summary>
        /// <param name="options">The base options to apply to all created loggers. If <c>null</c>, a default <see cref="PowerShellLoggerOptions"/> instance is used.</param>
        public PowerShellLoggerProvider(PowerShellLoggerOptions? options = null)
        {
            _baseOptions = options ?? new PowerShellLoggerOptions();
        }

        /// <summary>
        /// Creates a new <see cref="PowerShellLogger"/> with the given category name.
        /// </summary>
        /// <param name="categoryName">The logger category name (typically a cmdlet name or type name).</param>
        /// <returns>A <see cref="PowerShellLogger"/> bound to the specified category.</returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new PowerShellLogger(categoryName, _baseOptions);
        }


        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
