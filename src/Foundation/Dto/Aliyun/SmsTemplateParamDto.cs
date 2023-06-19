using System.Text.Json.Serialization;

namespace Bubble.Library.Foundation.Dto.Aliyun
{
    /// <summary>
    /// 短信模板参数
    /// </summary>
    public class SmsTemplateParamDto
    {
        /// <summary>
        /// 验证码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 摘要、评论
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}
