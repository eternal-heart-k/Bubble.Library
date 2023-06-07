namespace Bubble.Library.Foundation.Dto.Common
{
    /// <summary>
    /// 接口结果基类型 
    /// </summary>
    public class ApiResult
    {
        public ApiResult()
        {
        }

        public ApiResult(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// 接口执行成功标识
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 操作Id
        /// </summary>
        public string OperationId { get; set; }
    }

    /// <summary>
    /// 统一函数返回值
    /// </summary>
    public class ApiResult<TResult> : ApiResult
    {
        public ApiResult()
        {
        }

        public ApiResult(int errorCode, string message, TResult result = default) : base(errorCode, message)
        {
            Result = result;
        }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public TResult Result { get; set; }
    }
}
