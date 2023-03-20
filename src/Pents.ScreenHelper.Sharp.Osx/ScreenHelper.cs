using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;
using Pents.ScreenHelper.Sharp.Extensions;
using Pents.ScreenHelper.Sharp.Models;
using Pents.ScreenHelper.Sharp.Osx.External;
using Pents.ScreenHelper.Sharp.Osx.External.Models;

namespace Pents.ScreenHelper.Sharp.Osx;

public class ScreenHelper : IScreenHelper
{
    private readonly ILogger<ScreenHelper> _logger;

    public ScreenHelper(ILogger<ScreenHelper> logger)
    {
        _logger = logger;
    }

    public string? GetCurrentActiveWindowName()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStrPointer = ScreenHelperExternal_Arm.GetCurrentActiveWindowNameExternal();
            var str = Marshal.PtrToStringUTF8(externalStrPointer);
            ScreenHelperExternalReleaser_Arm.ReleaseString(externalStrPointer);
            return str;
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }
       
    public string? TryGetCurrentActiveWindowName()
    {
        try
        {
            return GetCurrentActiveWindowName();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Could not get current active window name");
            return null;
        }
    }

    public ScreenResolutionDto GetScreenResolution()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetScreenResolutionExternal();
            var @struct = Marshal.PtrToStructure<ScreenWidthHeightExternal>(externalStructPointer);
            ScreenHelperExternalReleaser_Arm.ReleaseScreenWidthHeight(externalStructPointer);
            return new ScreenResolutionDto(@struct.Width, @struct.Height);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }
    
    public ScreenResolutionDto? TryGetScreenResolution()
    {
        try
        {
            return GetScreenResolution();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Could not get screen resolution");
            return null;
        }
    }

    public ScreenshotDto GetScreenshot()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetScreenshotExternal();
            var @struct = Marshal.PtrToStructure<ScreenshotExternal>(externalStructPointer);
            var data = GetByteArray(@struct.ImageData, @struct.DataLength);
            ScreenHelperExternalReleaser_Arm.ReleaseScreenshot(externalStructPointer); 
            return new ScreenshotDto(@struct.Width, @struct.Height, data);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }
    
    public ScreenshotDto? TryGetScreenshot()
    {
        try
        {
            return GetScreenshot();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Could not get screen resolution");
            return null;
        }
    }

    public ScreenshotDto GetPartScreenshot(PartScreenshotParams @params)
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetPartScreenshotExternal(
                top:@params.Top,
                left:@params.Left,
                right:@params.Right,
                bottom:@params.Bottom);
            var @struct = Marshal.PtrToStructure<ScreenshotExternal>(externalStructPointer);
            var data = GetByteArray(@struct.ImageData, @struct.DataLength);
            ScreenHelperExternalReleaser_Arm.ReleaseScreenshot(externalStructPointer); 
            return new ScreenshotDto(@struct.Width, @struct.Height, data);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }
    
    public ScreenshotDto? TryGetPartScreenshot(PartScreenshotParams @params)
    {
        try
        {
            return GetScreenshot();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Could not get screen resolution");
            return null;
        }
    }

    public ScreenCoordsDto GetObjectOnScreenCoordinates(object template)
    {
        throw new NotImplementedException();
    }

    private byte[] GetByteArray(nint arrayPtr, int length)
    {
        var managedArray = new byte[length];
        Marshal.Copy(arrayPtr, managedArray, 0, length);
        return managedArray;
    }
}