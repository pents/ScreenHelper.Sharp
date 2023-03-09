using System.Runtime.InteropServices;
using Pents.ScreenHelper.Sharp.Constants;
using Pents.ScreenHelper.Sharp.Osx.Models;

namespace Pents.ScreenHelper.Sharp.Osx.External;

public static class ScreenHelperExternal
{
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = "GetScreenResolutionExternal")]
    public static extern ScreenWidthHeightExternal GetScreenResolutionExternal_Arm();
}