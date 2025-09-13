using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Provides a lazily-initialized, module-wide <see cref="ILoggerFactory"/> and helpers to create <see cref="ILogger"/> instances that write to the PowerShell logger provider.
    /// </summary>
    /// <remarks>
    /// The underlying factory is created on first access and reused. Call <see cref="Reset"/> to dispose the current factory and reinitialize it (e.g., after option changes).
    /// </remarks>
    internal static class ModuleLoggerFactory
    {
        private static Lazy<ILoggerFactory> _factory = CreateLazyFactory();

        /// <summary>
        /// Gets the shared <see cref="ILoggerFactory"/> for the module.
        /// </summary>
        public static ILoggerFactory Factory
        {
            get => _factory.Value;
        }

        /// <summary>
        /// Creates a typed <see cref="ILogger"/> using the shared <see cref="Factory"/>.
        /// </summary>
        /// <typeparam name="T">The category type for the logger.</typeparam>
        /// <returns>An <see cref="ILogger{TCategoryName}"/> for the specified type.</returns>
        public static ILogger<T> CreateLogger<T>()
        {
            return Factory.CreateLogger<T>();
        }

        /// <summary>
        /// Creates an <see cref="ILogger"/> for the specified category name
        /// using the shared <see cref="Factory"/>.
        /// </summary>
        /// <param name="categoryName">The logger category name.</param>
        /// <returns>An <see cref="ILogger"/> for the given category.</returns>
        public static ILogger CreateLogger(string categoryName)
        {
            return Factory.CreateLogger(categoryName);
        }

        /// <summary>
        /// Disposes the current factory (if created) and replaces it with a new one.
        /// </summary>
        /// <remarks>
        /// This is thread-safe and uses <see cref="Interlocked.Exchange{T}(ref T, T)"/>
        /// to swap the backing <see cref="Lazy{T}"/> instance. If the previous
        /// <see cref="Lazy{T}"/> had been realized, its value is disposed.
        /// </remarks>
        public static void Reset()
        {
            Lazy<ILoggerFactory> old = Interlocked.Exchange(ref _factory, CreateLazyFactory());

            if (old.IsValueCreated)
                old.Value.Dispose();
        }

        /// <summary>
        /// Creates a lazily-initialized <see cref="ILoggerFactory"/> configured for PowerShell.
        /// </summary>
        /// <returns>A new <see cref="Lazy{T}"/> that builds an <see cref="ILoggerFactory"/>.</returns>
        private static Lazy<ILoggerFactory> CreateLazyFactory()
        {
            return new Lazy<ILoggerFactory>(
                () =>
                {
                    ILoggerFactory factory = LoggerFactory.Create(builder =>
                    {
                        builder.ClearProviders();
                        builder.AddProvider(new PowerShellLoggerProvider(new PowerShellLoggerOptions()));
                        builder.SetMinimumLevel(LogLevel.Information);
                    });

                    return factory;
                },
                LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}
