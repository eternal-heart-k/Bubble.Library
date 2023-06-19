using System.Collections.Generic;

namespace Bubble.Library.Foundation.Dto.Aliyun
{
    /// <summary>
    /// 批量发送短信入参
    /// </summary>
    public class SmsBatchInputDto : SmsBaseDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public List<string> PhoneNumber { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public List<string> SignName { get; set; }

        /// <summary>
        /// 短信模板
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 短信模板参数
        /// </summary>
        public List<SmsTemplateParamDto> SmsTemplateParam { get; set; }
    }
}
