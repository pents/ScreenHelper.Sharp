using System.Runtime.InteropServices;
using Pents.ScreenHelper.Sharp.Constants;

namespace Pents.ScreenHelper.Sharp.Osx.External;

public static class ScreenHelperExternal_Arm
{
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetScreenResolutionExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetScreenResolutionExternal();

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetCurrentActiveWindowNameExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetCurrentActiveWindowNameExternal();
}

public static class ScreenHelperExternalReleaser_Arm
{
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseScreenWidthHeight), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseScreenWidthHeight(nint screenInfoPtr);
    
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseString), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseString(nint strPtr);
}