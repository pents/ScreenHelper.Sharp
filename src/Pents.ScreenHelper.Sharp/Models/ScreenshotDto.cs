namespace Pents.ScreenHelper.Sharp.Models;

public abstract record ScreenshotBaseDto(uint Width, uint Height);
public record ScreenshotDto(uint Width, uint Height, byte[] Data) : ScreenshotBaseDto(Width, Height);
public record ScreenshotCachingDto(uint Width, uint Height, Guid DataPtr) : ScreenshotBaseDto(Width, Height);