using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Osx.External.Models;

[StructLayout(LayoutKind.Sequential)]
internal class BaseStruct
{
    public nint Exception;
    public int ExceptionLength;
}