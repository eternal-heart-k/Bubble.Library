namespace Bubble.Library.Foundation.Dto.Common
{
    /// <summary>
    /// 接口结果基类型 
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
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

        public static ApiResult Success(string operationId)
        {
            return new ApiResult
            {
                IsSuccess = true,
                OperationId = operationId
            };
        }

        public static ApiResult<T> Success<T>(T result, string operationId)
        {
            return new ApiResult<T>
            {
                IsSuccess = true,
                Result = result,
                OperationId = operationId
            };
        }

        public static ApiResult Error(int errorCode, string message, string operationId)
        {
            return new ApiResult
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                Message = message,
                OperationId = operationId
            };
        }
    }

    /// <summary>
    /// 统一函数返回值
    /// </summary>
    public class ApiResult<TResult> : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
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
