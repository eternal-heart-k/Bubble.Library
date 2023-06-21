using System.Text.Json.Serialization;

namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 获取用户OpenID_OAuth2.0出参
    /// </summary>
    public class QQOpenIdOutputDto : QQErrorBaseDto
    {
        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appid
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// 唯一对应用户身份的标识
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
    }
}
