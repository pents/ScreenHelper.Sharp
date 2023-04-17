namespace Pents.ScreenHelper.Sharp.Models;

public class ScreenCacheObject
{
    public ScreenCacheObject(nint ptr, ulong dataLength)
    {
        Ptr = ptr;
        DataLength = dataLength;
    }
    
    public nint Ptr;
    public ulong DataLength;
}