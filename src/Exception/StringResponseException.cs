namespace Bubble.Library.Exception
{
    /// <summary>
    /// 外部使用异常
    /// Controller使用ApiBaseController或使用ApiResponse属性将自动结合ApiResult抛出
    /// </summary>
    public class StringResponseException : ResponseExceptionBase
    {
        /// <summary>
        /// 异常消息
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// 含有错误码的异常消息
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        public StringResponseException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            Message = errorMessage;
        }

        /// <summary>
        /// 只含异常消息
        /// </summary>
        /// <param name="errorMessage"></param>
        public StringResponseException(string errorMessage) : this(0, errorMessage)
        {
        }
    }
}
