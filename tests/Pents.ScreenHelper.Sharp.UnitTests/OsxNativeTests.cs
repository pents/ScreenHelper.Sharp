using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;

namespace Pents.ScreenHelper.Sharp.UnitTests;

public class OsxNativeTests
{
    private readonly IScreenHelper _screenHelper;
    public OsxNativeTests()
    {
        var loggerFactory = new LoggerFactory();
        _screenHelper = new Osx.ScreenHelper(loggerFactory.CreateLogger<Osx.ScreenHelper>());
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
    
}