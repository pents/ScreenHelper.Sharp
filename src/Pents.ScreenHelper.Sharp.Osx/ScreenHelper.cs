using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;
using Pents.ScreenHelper.Sharp.Extensions;
using Pents.ScreenHelper.Sharp.Models;
using Pents.ScreenHelper.Sharp.Osx.Extensions;
using Pents.ScreenHelper.Sharp.Osx.External;
using Pents.ScreenHelper.Sharp.Osx.External.Models;

namespace Pents.ScreenHelper.Sharp.Osx;

public class ScreenHelper : IScreenHelper
{
    private readonly ILogger<ScreenHelper> _logger;

    public ScreenHelper(ILogger<ScreenHelper> logger)
    {
        _logger = logger;
    }

    public string? GetCurrentActiveWindowName()
    {
        if (CpuExtensions.IsArm())
        {
            var ptr = ScreenHelperExternal_Arm.GetCurrentActiveWindowNameExternal();
            var @struct = Marshal.PtrToStructure<ActiveWindowName>(ptr);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseActiveWindowName(ptr));
            return Marshal.PtrToStringUTF8(@struct.Name);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public bool TryGetCurrentActiveWindowName(out string? name)
    {
        try
        {
            name = GetCurrentActiveWindowName();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(GetCurrentActiveWindowName)}");
            name = null;
        }

        return false;
    }
    

    public ScreenResolutionDto GetScreenResolution()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetScreenResolutionExternal();
            var @struct = Marshal.PtrToStructure<ScreenWidthHeightExternal>(externalStructPointer);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseScreenWidthHeight(externalStructPointer));
            return new ScreenResolutionDto(@struct.Width, @struct.Height);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public bool TryGetScreenResolution(out ScreenResolutionDto? dto)
    {
        try
        {
            dto = GetScreenResolution();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(GetScreenResolution)}");
            dto = null;
        }

        return false;
    }
    
    public ScreenshotDto GetScreenshot()
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetScreenshotExternal();
            var @struct = Marshal.PtrToStructure<ScreenshotExternal>(externalStructPointer);
            var data = GetByteArray(@struct.ImageData, @struct.DataLength);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseScreenshot(externalStructPointer));
            Debug.Assert(data != null, nameof(data) + " != null");
            return new ScreenshotDto(@struct.Width, @struct.Height, data);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }
    
    public bool TryGetScreenshot(out ScreenshotDto? dto)
    {
        try
        {
            dto = GetScreenshot();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(GetScreenshot)}");

            dto = null;
        }
        
        return false;
    }

    public ScreenshotDto GetPartScreenshot(PartScreenshotParams @params)
    {
        if (CpuExtensions.IsArm())
        {
            var externalStructPointer = ScreenHelperExternal_Arm.GetPartScreenshotExternal(
                top:@params.Top,
                left:@params.Left,
                right:@params.Right,
                bottom:@params.Bottom);
            var @struct = Marshal.PtrToStructure<ScreenshotExternal>(externalStructPointer);
            var data = GetByteArray(@struct.ImageData, @struct.DataLength);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseScreenshot(externalStructPointer));
            Debug.Assert(data != null, nameof(data) + " != null");
            return new ScreenshotDto(@struct.Width, @struct.Height, data);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public bool TryGetPartScreenshot(PartScreenshotParams args, out ScreenshotDto? dto)
    {
        try
        {
            dto = GetScreenshot();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(GetPartScreenshot)}");
            dto = null;
        }

        return false;
    }

    public ScreenCoordsDto FindImageInScreen(byte[] template)
    {
        if (CpuExtensions.IsArm())
        {
            var imageData = new ImageData
            {
                Data = template,
                DataCount = (ulong)template.LongLength, // length is always positive - so unchecked is not necessary
            };
            var ptr = ScreenHelperExternal_Arm.FindImageInScreenExternal(ref imageData);
            var @struct = Marshal.PtrToStructure<ScreenCoordsWithConfidence>(ptr);
            @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseFoundPoint(ptr));
            return new ScreenCoordsDto(@struct.X, @struct.Y, @struct.Confidence);
        }
        else
        {
            throw new NotImplementedException("x64 is not supported yet");
        }
    }

    public bool TryFindImageInScreen(byte[] template, out ScreenCoordsDto? dto)
    {
        try
        {
            dto = FindImageInScreen(template);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(FindImageInScreen)}");
            dto = null;
        }

        return false;
    }

    public double GetImageSimilarity(byte[] first, byte[] second)
    {
        var imageData1 = new ImageData
        {
            Data = first,
            DataCount = (ulong)first.LongLength, // length is always positive - so unchecked is not necessary
        };
        var imageData2 = new ImageData
        {
            Data = second,
            DataCount = (ulong)second.LongLength, // length is always positive - so unchecked is not necessary
        };
        
        var ptr = ScreenHelperExternal_Arm.SimilarityExternal(ref imageData1, ref imageData2);
        var @struct = Marshal.PtrToStructure<SimilarityResult>(ptr);
        @struct.RaiseExceptionIfExistAndRelease(() => ScreenHelperExternalReleaser_Arm.ReleaseSimilarityResult(ptr));
        return @struct.Value;
    }

    public bool TryGetImageSimilarity(byte[] first, byte[] second, out double? similarity)
    {
        try
        {
            similarity = GetImageSimilarity(first, second);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{nameof(ScreenHelper)}] Error in method {nameof(GetImageSimilarity)}");
            similarity = null;
        }

        return false;
    }

    // TODO: needs testing
    private byte[]? GetByteArray(nint arrayPtr, ulong length)
    {
        if (length > 0)
        {
            var maxChunkSize = int.MaxValue; // Maximum chunk size for 32-bit platforms
            if (nint.Size == 8)
            {
                maxChunkSize = int.MaxValue / 2; // Maximum chunk size for 64-bit platforms
            }

            var data = new byte[length];
            long offset = 0;

            while (offset < (long)length)
            {
                var chunkSize = (int)Math.Min((ulong)maxChunkSize, length - (ulong)offset);
                Marshal.Copy((nint)(arrayPtr + offset), data, (int)offset, chunkSize);
                offset += chunkSize;
            }

            return data;
        }

        return null;
    }
}