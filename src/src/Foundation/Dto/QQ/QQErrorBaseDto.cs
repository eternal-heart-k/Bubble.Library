using System.Text.Json.Serialization;

namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// QQ接口调用错误返回
    /// </summary>
    public class QQErrorBaseDto
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonPropertyName("error")]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonPropertyName("error_description")]
        public string ErrorMessage { get; set; }
    }
}
