using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal struct ScreenshotExternal
{
    public uint Width;
    public uint Height;
    public nint ImageData;
    public int DataLength;
}