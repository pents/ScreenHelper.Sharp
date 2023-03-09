using Pents.ScreenHelper.Sharp.Models;

namespace Pents.ScreenHelper.Sharp.Abstractions;

public interface IScreenHelper
{
    string GetCurrentActiveWindow();
    ScreenResolutionDto GetScreenResolution();
    ScreenCoordsDto GetObjectOnScreenCoordinates(object template);
}