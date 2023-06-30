using System.Runtime.Serialization;

namespace Bubble.Library.Exception
{
    /// <summary>
    /// Bubble.Library内部使用异常，外部使用异常建议使用StringResponseException
    /// </summary>
    public class InnerException : System.Exception
    {
        /// <summary>
        /// 新的异常对象
        /// </summary>
        public InnerException()
        {

        }

        /// <summary>
        /// 新的异常对象
        /// </summary>
        /// <param name="message"></param>
        public InnerException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 新的异常对象
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InnerException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// 序列化构造
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="context"></param>
        public InnerException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
