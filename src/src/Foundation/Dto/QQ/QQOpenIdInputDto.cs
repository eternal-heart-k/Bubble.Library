namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 获取用户OpenID_OAuth2.0入参
    /// </summary>
    public class QQOpenIdInputDto
    {
        /// <summary>
        /// 获取到的access token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 因历史原因，默认是jsonpb格式，如果填写json，则返回json格式
        /// </summary>
        public string fmt { get; set; } = "json";
    }
}
