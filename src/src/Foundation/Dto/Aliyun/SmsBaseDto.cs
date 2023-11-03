namespace Bubble.Library.Foundation.Dto.Aliyun
{
    /// <summary>
    /// SMS基类Dto
    /// </summary>
    public class SmsBaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string EndPoint { get; set; } = "dysmsapi.aliyuncs.com";

        /// <summary>
        /// 
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessKeySecret { get; set; }
    }
}
