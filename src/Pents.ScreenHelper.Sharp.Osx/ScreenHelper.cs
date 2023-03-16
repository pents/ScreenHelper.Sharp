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
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Could not get current active window name");
            return null;
        }
    }

    public ScreenResolutionDto? GetScreenResolution()
    {
        try
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
}