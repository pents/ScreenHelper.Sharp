using Pents.ScreenHelper.Sharp.Models;

namespace Pents.ScreenHelper.Sharp.Abstractions;

public interface IScreenHelper
{
    string? GetCurrentActiveWindowName();
    string? TryGetCurrentActiveWindowName();
    
    
    ScreenResolutionDto GetScreenResolution();
    ScreenResolutionDto? TryGetScreenResolution();
    
    
    ScreenshotDto GetScreenshot();
    ScreenshotDto? TryGetScreenshot();
    
    
    ScreenshotDto GetPartScreenshot(PartScreenshotParams args);
    ScreenshotDto? TryGetPartScreenshot(PartScreenshotParams args);
    
    ScreenCoordsDto GetObjectOnScreenCoordinates(object template); // TODO
}