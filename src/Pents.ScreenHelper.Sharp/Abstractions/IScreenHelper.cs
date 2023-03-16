using Pents.ScreenHelper.Sharp.Models;

namespace Pents.ScreenHelper.Sharp.Abstractions;

public interface IScreenHelper
{
    string? GetCurrentActiveWindowName();
    ScreenResolutionDto? GetScreenResolution();
    ScreenCoordsDto GetObjectOnScreenCoordinates(object template);
}