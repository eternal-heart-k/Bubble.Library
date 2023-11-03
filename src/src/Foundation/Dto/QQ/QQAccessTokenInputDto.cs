namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 通过Authorization Code获取Access Token入参
    /// </summary>
    public class QQAccessTokenInputDto
    {
        /// <summary>
        /// 授权类型，在本步骤中，此值为“authorization_code”
        /// </summary>
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appid
        /// </summary>
        public string client_id { get; set; }

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey
        /// </summary>
        public string client_secret { get; set; }

        /// <summary>
        /// 上一步返回的authorization code
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 与上面一步中传入的redirect_uri保持一致
        /// </summary>
        public string redirect_uri { get; set; }

        /// <summary>
        /// 默认是x-www-form-urlencoded格式，如果填写json，则返回json格式
        /// </summary>
        public string fmt { get; set; } = "json";
    }
}
