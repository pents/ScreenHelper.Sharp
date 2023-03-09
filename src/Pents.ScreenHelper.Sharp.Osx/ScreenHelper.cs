using Pents.ScreenHelper.Sharp.Abstractions;
using Pents.ScreenHelper.Sharp.Extensions;
using Pents.ScreenHelper.Sharp.Models;
using Pents.ScreenHelper.Sharp.Osx.External;

namespace Pents.ScreenHelper.Sharp.Osx;

public class ScreenHelper : IScreenHelper
{
    public string GetCurrentActiveWindow()
    {
        throw new NotImplementedException();
    }

    public ScreenResolutionDto GetScreenResolution()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStruct = ScreenHelperExternal.GetScreenResolutionExternal_Arm();
            return new ScreenResolutionDto(externalStruct.Width, externalStruct.Height);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public ScreenCoordsDto GetObjectOnScreenCoordinates(object template)
    {
        throw new NotImplementedException();
    }
}