using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal class ScreenWidthHeightExternal : BaseStruct
{
    public uint Width;
    public uint Height;
}