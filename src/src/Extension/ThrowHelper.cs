using System.Diagnostics.CodeAnalysis;
using Bubble.Library.Exception;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// 异常抛出相关
    /// </summary>
    public static class ThrowHelper
    {
        /// <summary>
        /// 报异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="StringResponseException"></exception>
        [DoesNotReturn]
        public static void Throw(string message)
        {
            throw new StringResponseException(message);
        }

        /// <summary>
        /// 报异常消息，带有错误码
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <exception cref="StringResponseException"></exception>
        [DoesNotReturn]
        public static void Throw(int errorCode, string message)
        {
            throw new StringResponseException(errorCode, message);
        }
    }
}
