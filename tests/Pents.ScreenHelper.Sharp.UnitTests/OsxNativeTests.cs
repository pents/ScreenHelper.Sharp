using Pents.ScreenHelper.Sharp.Abstractions;

namespace Pents.ScreenHelper.Sharp.UnitTests;

public class OsxNativeTests
{
    [Fact]
    public void ItShould_GetCurrentScreenResolution()
    {
        IScreenHelper screenHelper = new Osx.ScreenHelper();

        var result = screenHelper.GetScreenResolution();
    }
}