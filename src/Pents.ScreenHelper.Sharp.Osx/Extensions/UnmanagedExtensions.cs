using System.Runtime.InteropServices;
using Pents.ScreenHelper.Sharp.Osx.Exceptions;
using Pents.ScreenHelper.Sharp.Osx.External.Models;

namespace Pents.ScreenHelper.Sharp.Osx.Extensions;

// TODO: Maybe it should be on higher level alongside BaseStruct
internal static class UnmanagedExtensions
{
    /// <summary>
    /// <p>Checks if there is an exception in unmanaged struct and raises it if it exists</p>
    /// <p>Marshals struct and releases unmanaged memory otherwise</p>
    /// </summary>
    /// <param name="struct"></param>
    /// <param name="releaser"></param>
    /// <exception cref="Exception">Raises if @struct is null</exception>
    /// <exception cref="ScreenHelperOsxException">Raises if there is an error on native code side</exception>
    public static void RaiseExceptionIfExistAndRelease(this BaseStruct? @struct, Action releaser)
    {
        try
        {
            if (@struct is null)
                throw new Exception($"[{nameof(ScreenHelper)}] Could not read struct");
        
            if (@struct.ExceptionLength <= 0) 
                return;
        
            var errorMessage = Marshal.PtrToStringUTF8(@struct.Exception);
            if (errorMessage is null)
            {
                throw new ScreenHelperOsxException($"[{nameof(ScreenHelper)}] Could not parse exception");
            }
            
            throw new ScreenHelperOsxException(errorMessage);
        }
        finally
        {
            releaser();
        }
        
    }
}