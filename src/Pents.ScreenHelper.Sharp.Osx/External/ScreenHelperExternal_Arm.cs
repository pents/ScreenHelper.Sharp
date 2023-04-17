using System.Runtime.InteropServices;
using Pents.ScreenHelper.Sharp.Constants;
using Pents.ScreenHelper.Sharp.Osx.External.Models;

namespace Pents.ScreenHelper.Sharp.Osx.External;

internal static class ScreenHelperExternal_Arm
{
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetScreenResolutionExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetScreenResolutionExternal();

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetCurrentActiveWindowNameExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetCurrentActiveWindowNameExternal();

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetScreenshotExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetScreenshotExternal();

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(GetPartScreenshotExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint GetPartScreenshotExternal(uint top, uint left, uint right, uint bottom);

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(SimilarityExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint SimilarityExternal(ref ImageData image1, ref ImageData image2);
    
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(FindImageInScreenExternal), CallingConvention = CallingConvention.Cdecl)]
    public static extern nint FindImageInScreenExternal(ref ImageData pattern);
}

internal static class ScreenHelperExternalReleaser_Arm
{
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseScreenWidthHeight), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseScreenWidthHeight(nint screenInfoPtr);

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseActiveWindowName), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseActiveWindowName(nint scrPtr);
    
    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseString), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseString(nint strPtr);

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseScreenshot), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseScreenshot(nint scrPtr);

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseFoundPoint), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseFoundPoint(nint scrPtr);

    [DllImport(NativeLibPaths.OSX_ARM_PATH, EntryPoint = nameof(ReleaseSimilarityResult), CallingConvention = CallingConvention.Cdecl)]
    public static extern void ReleaseSimilarityResult(nint scrPtr);
}