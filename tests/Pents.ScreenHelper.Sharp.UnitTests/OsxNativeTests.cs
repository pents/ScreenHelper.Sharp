using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;
using Pents.ScreenHelper.Sharp.Models;
using Pents.ScreenHelper.Sharp.UnitTests.Helpers;
using Xunit.Abstractions;

namespace Pents.ScreenHelper.Sharp.UnitTests;

public class OsxNativeTests
{
    private readonly IScreenHelper _screenHelper;

    public OsxNativeTests(ITestOutputHelper testOutputHelper)
    {
        var loggerFactory = new LoggerFactory(new List<ILoggerProvider>
        {
            new TestOutputLoggerProvider(testOutputHelper),
        });
        var logger = loggerFactory.CreateLogger<Osx.ScreenHelper>();
        _screenHelper = new Osx.ScreenHelper(logger);
    }
    
    [Fact]
    public void ItShould_GetCurrentScreenResolution()
    {
        var result = _screenHelper.GetScreenResolution();
        
        Assert.NotNull(result);
        Assert.NotEqual((uint)0, result.Height);
        Assert.NotEqual((uint)0, result.Width);
    }

    [Fact]
    public void ItShould_GetCurrentActiveWindowName()
    {
        var result = _screenHelper.GetCurrentActiveWindowName();
        
        Assert.NotNull(result);
    }

    [Fact]
    public void ItShould_GetScreenshot()
    {
        var result = _screenHelper.GetScreenshot();

        Assert.NotNull(result);
    }
    
    
    [Fact]
    public void ItShould_GetPartScreenshot()
    {
        var args = new PartScreenshotParams
        {
            Top = 200,
            Left = 400,
            Right = 600,
            Bottom = 500,
        };
        
        var result = _screenHelper.GetPartScreenshot(args);

        Assert.NotNull(result);
    }
}