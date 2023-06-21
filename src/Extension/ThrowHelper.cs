using System.Diagnostics.CodeAnalysis;
using Bubble.Library.Exception;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// 异常抛出相关
    /// </summary>
    public static class ThrowHelper
    {
        [DoesNotReturn]
        public static void Throw(string message)
        {
            throw new StringResponseException(message);
        }

        [DoesNotReturn]
        public static void Throw(int errorCode, string message)
        {
            throw new StringResponseException(errorCode, message);
        }
    }
}
