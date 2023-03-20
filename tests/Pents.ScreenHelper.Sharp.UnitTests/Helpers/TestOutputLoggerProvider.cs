using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Pents.ScreenHelper.Sharp.UnitTests.Helpers;

public class TestOutputLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestOutputLoggerProvider(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public void Dispose()
    {
        
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new TestOutputLogger(_testOutputHelper);
    }
}

public class TestOutputLogger : ILogger
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestOutputLogger(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        _testOutputHelper.WriteLine(formatter(state, exception));
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return new TestOutputLoggerScope();
    }
}

public class TestOutputLoggerScope : IDisposable
{
    public void Dispose()
    {
    }
}