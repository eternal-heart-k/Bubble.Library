namespace Bubble.Library.Foundation.Constant
{
    /// <summary>
    /// QQ常量
    /// </summary>
    public static class QQConstant
    {
        /// <summary>
        /// Get
        /// PC网站获取Authorization Code请求地址
        /// </summary>
        public static string AuthorizationCodeRequestUrl => "https://graph.qq.com/oauth2.0/authorize";

        /// <summary>
        /// Get
        /// PC网站获取Access Token请求地址
        /// </summary>
        public static string AccessTokenRequestUrl => "https://graph.qq.com/oauth2.0/token";

        /// <summary>
        /// Get
        /// PC网站获取用户OpenID_OAuth2.0请求地址
        /// </summary>
        public static string OpenIdRequestUrl => "https://graph.qq.com/oauth2.0/me";

        /// <summary>
        /// Get
        /// 获取用户信息请求地址
        /// </summary>
        public static string UserInfoRequestUrl => "https://graph.qq.com/user/get_user_info";
    }
}
