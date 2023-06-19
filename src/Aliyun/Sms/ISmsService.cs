using Bubble.Library.Foundation.Dto.Aliyun;
using System.Threading.Tasks;

namespace Bubble.Library.Aliyun.Sms
{
    public interface ISmsService
    {
        /// <summary>
        /// 单个发送短信验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsResponse SendSms(SmsInputDto dto);

        /// <summary>
        /// 单个发送短信验证码（异步）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsResponse> SendSmsAsync(SmsInputDto dto);

        /// <summary>
        /// 批量发送短信验证码，单次最多支持100个
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsResponse SendBatchSms(SmsBatchInputDto dto);

        /// <summary>
        /// 批量发送短信验证码，单次最多支持100个（异步）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsResponse> SendBatchSmsAsync(SmsBatchInputDto dto);
    }
}
