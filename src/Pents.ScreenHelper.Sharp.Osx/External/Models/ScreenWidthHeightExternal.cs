using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal struct ScreenWidthHeightExternal
{
    public uint Width;
    public uint Height;
}