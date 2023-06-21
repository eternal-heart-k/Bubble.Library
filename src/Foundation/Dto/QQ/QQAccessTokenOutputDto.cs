using System.Text.Json.Serialization;

namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 通过Authorization Code获取Access Token出参
    /// </summary>
    public class QQAccessTokenOutputDto : QQErrorBaseDto
    {
        /// <summary>
        /// 授权令牌，Access_Token
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 该access token的有效期，单位为秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// 在授权自动续期步骤中，获取新的Access_Token时需要提供的参数
        /// 注：refresh_token仅一次有效
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
