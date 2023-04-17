using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;
using Pents.ScreenHelper.Sharp.Extensions;
using Pents.ScreenHelper.Sharp.Models;
using Pents.ScreenHelper.Sharp.Osx.Extensions;
using Pents.ScreenHelper.Sharp.Osx.External;
using Pents.ScreenHelper.Sharp.Osx.External.Models;

namespace Pents.ScreenHelper.Sharp.Osx;

public class CachingScreenHelper : ICachingScreenHelper
{
    private readonly ILogger<ScreenHelper> _logger;
    private readonly ICacheManager<ScreenCacheObject> _screenCacheManager;

    public CachingScreenHelper(ILogger<ScreenHelper> logger, ICacheManager<ScreenCacheObject> screenCacheManager)
    {
        _logger = logger;
        _screenCacheManager = screenCacheManager;
    }

    public ScreenshotCachingDto GetScreenshot()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetScreenshotExternal();
            var @struct = Marshal.PtrToStructure<ScreenshotExternal>(externalStructPointer);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseScreenshot(externalStructPointer));

            _screenCacheManager.Add(new ScreenCacheObject(@struct.ImageData, @struct.DataLength));
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public bool TryGetScreenshot(out ScreenshotCachingDto? dto)
    {
        
    }

    public ScreenshotCachingDto GetPartScreenshot(PartScreenshotParams args)
    {
        
    }

    public bool TryGetPartScreenshot(PartScreenshotParams args, out ScreenshotCachingDto? dto)
    {
        
    }

    public ScreenCoordsDto FindImageInScreen(ScreenshotCachingDto template)
    {
        
    }

    public bool TryFindImageInScreen(ScreenshotCachingDto template, out ScreenCoordsDto? dto)
    {
        
    }

    public double GetImageSimilarity(ScreenshotCachingDto first, ScreenshotCachingDto second)
    {
        
    }

    public bool TryGetImageSimilarity(ScreenshotCachingDto first, ScreenshotCachingDto second, out double? similarity)
    {
        
    }

    public ScreenshotCachingDto CacheImage(byte[] image)
    {
        
    }
}