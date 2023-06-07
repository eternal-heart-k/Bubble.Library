using System.Diagnostics.CodeAnalysis;
using Bubble.Library.Exception;

namespace Bubble.Library.Shared.Extension
{
    public static class ThrowHelper
    {
        [DoesNotReturn]
        public static void Throw(string message)
        {
            throw new StringResponseException(message);
        }
    }
}
