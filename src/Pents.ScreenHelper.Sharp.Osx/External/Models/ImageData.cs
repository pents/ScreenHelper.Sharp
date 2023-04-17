using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal struct ImageData
{
    public byte[] Data;
    public ulong DataCount;
}