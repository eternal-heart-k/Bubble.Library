using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension;
using Bubble.Library.Foundation.Dto.Aliyun;
using Microsoft.Extensions.Logging;
using Tea;

namespace Bubble.Library.Aliyun.Sms
{
    public class SmsService : ISmsService, ITransientDependency
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 单个发送短信验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsResponse SendSms(SmsInputDto dto)
        {
            if (dto.PhoneNumber.IsNullOrWhiteSpace())
                return null;

            var client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = dto.AccessKeyId,
                AccessKeySecret = dto.AccessKeySecret,
                Endpoint = dto.EndPoint
            });
            try
            {
                return client.SendSmsWithOptions(GetSendSmsRequest(dto), new AlibabaCloud.TeaUtil.Models.RuntimeOptions());
            }
            catch (TeaException ex)
            {
                _logger.LogError($"单个发送短信验证码失败，异常消息是：{ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// 单个发送短信验证码（异步）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsResponse> SendSmsAsync(SmsInputDto dto)
        {
            if (dto.PhoneNumber.IsNullOrWhiteSpace())
                return null;

            var client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = dto.AccessKeyId,
                AccessKeySecret = dto.AccessKeySecret,
                Endpoint = dto.EndPoint
            });
            try
            {
                return await client.SendSmsWithOptionsAsync(GetSendSmsRequest(dto), new AlibabaCloud.TeaUtil.Models.RuntimeOptions());
            }
            catch (TeaException ex)
            {
                _logger.LogError($"单个发送短信验证码失败，异常消息是：{ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// 批量发送短信验证码，单次最多支持100个
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsResponse SendBatchSms(SmsBatchInputDto dto)
        {
            if (!dto.PhoneNumber.Any())
                return null;

            var client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = dto.AccessKeyId,
                AccessKeySecret = dto.AccessKeySecret,
                Endpoint = dto.EndPoint
            });
            try
            {
                return client.SendBatchSmsWithOptions(GetSendBatchSmsRequest(dto), new AlibabaCloud.TeaUtil.Models.RuntimeOptions());
            }
            catch (TeaException ex)
            {
                _logger.LogError($"批量发送短信验证码失败，异常消息是：{ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// 批量发送短信验证码，单次最多支持100个
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsResponse> SendBatchSmsAsync(SmsBatchInputDto dto)
        {
            if (!dto.PhoneNumber.Any())
                return null;

            var client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = dto.AccessKeyId,
                AccessKeySecret = dto.AccessKeySecret,
                Endpoint = dto.EndPoint
            });
            try
            {
                return await client.SendBatchSmsWithOptionsAsync(GetSendBatchSmsRequest(dto), new AlibabaCloud.TeaUtil.Models.RuntimeOptions());
            }
            catch (TeaException ex)
            {
                _logger.LogError($"批量发送短信验证码失败，异常消息是：{ex.Message}", ex);
                throw;
            }
        }

        private AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest GetSendSmsRequest(SmsInputDto dto)
        {
            return new AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest
            {
                TemplateCode = dto.TemplateCode,
                PhoneNumbers = dto.PhoneNumber,
                SignName = dto.SignName,
                TemplateParam = JsonSerializer.Serialize(dto.SmsTemplateParam)
            };
        }

        private AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsRequest GetSendBatchSmsRequest(SmsBatchInputDto dto)
        {
            return new AlibabaCloud.SDK.Dysmsapi20170525.Models.SendBatchSmsRequest
            {
                TemplateCode = dto.TemplateCode,
                PhoneNumberJson = JsonSerializer.Serialize(dto.PhoneNumber),
                SignNameJson = JsonSerializer.Serialize(dto.SignName),
                TemplateParamJson = JsonSerializer.Serialize(dto.SmsTemplateParam)
            };
        }
    }
}
