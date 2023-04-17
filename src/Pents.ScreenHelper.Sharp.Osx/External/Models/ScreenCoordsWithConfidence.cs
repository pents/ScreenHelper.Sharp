using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal class ScreenCoordsWithConfidence : BaseStruct
{
    public int X;
    public int Y;
    public double Confidence;
}