using Microsoft.Extensions.Logging;
using System;

namespace DevelopmentTests;
public class NoOpLogger<TCategoryName> : ILogger<TCategoryName>
{
    public IDisposable BeginScope<TState>(TState state) => new Scope();
    public bool IsEnabled(LogLevel logLevel) => true;
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
    }

    public class Scope : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
