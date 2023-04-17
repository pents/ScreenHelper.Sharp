using System.Runtime.InteropServices;

namespace Pents.ScreenHelper.Sharp.Extensions;

/// <summary>
/// Intended for internal use only
/// </summary>
public static class CpuExtensions
{
    public static bool IsArm()
    {
        switch (RuntimeInformation.OSArchitecture)
        {
            case Architecture.Arm64:
                return true;
            case Architecture.X64:
                return false;
            case Architecture.X86:
            case Architecture.Arm:
            case Architecture.Wasm:
            case Architecture.S390x:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}