using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
public struct ScreenWidthHeightExternal
{
    public uint Width;
    public uint Height;
}