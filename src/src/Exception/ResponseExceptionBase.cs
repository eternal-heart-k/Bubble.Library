namespace Bubble.Library.Exception
{
    /// <summary>
    /// 外部异常基类
    /// </summary>
    public abstract class ResponseExceptionBase : System.Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        protected ResponseExceptionBase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        protected ResponseExceptionBase(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
