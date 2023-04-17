using System.Runtime.Serialization;

namespace Pents.ScreenHelper.Sharp.Osx.Exceptions;

internal class ScreenHelperOsxException : Exception
{
    public ScreenHelperOsxException()
    {
        
    }

    public ScreenHelperOsxException(string message) : base(message)
    {
        
    }

    public ScreenHelperOsxException(string message, Exception inner) : base(message, inner)
    {
        
    }

    public ScreenHelperOsxException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        
    }
}