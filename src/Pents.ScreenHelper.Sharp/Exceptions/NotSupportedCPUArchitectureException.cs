using System.Runtime.Serialization;

namespace Pents.ScreenHelper.Sharp.Exceptions;

public class NotSupportedCPUArchitectureException : Exception
{
    public NotSupportedCPUArchitectureException()
    {
        
    }

    public NotSupportedCPUArchitectureException(string message) : base(message)
    {
        
    }

    public NotSupportedCPUArchitectureException(string message, Exception inner) : base(message, inner)
    {
        
    }

    public NotSupportedCPUArchitectureException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        
    }
}