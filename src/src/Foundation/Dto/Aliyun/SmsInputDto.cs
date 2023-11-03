using System.Collections.Generic;

namespace Bubble.Library.Foundation.Dto.Aliyun
{
    /// <summary>
    /// 发送单个短信入参
    /// </summary>
    public class SmsInputDto : SmsBaseDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }

        /// <summary>
        /// 短信模板
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 短信模板参数
        /// </summary>
        public Dictionary<string, string> SmsTemplateParam { get; set; }
    }
}
