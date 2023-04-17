using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal class ScreenshotExternal : BaseStruct
{
    public uint Width;
    public uint Height;
    public nint ImageData;
    public ulong DataLength;
}