namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 获取QQ用户信息入参
    /// </summary>
    public class QQUserInfoInputDto
    {
        /// <summary>
        /// 授权令牌，Access_Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid
        /// </summary>
        public string oauth_consumer_key { get; set; }

        /// <summary>
        /// 用户的ID，与QQ号码一一对应
        /// </summary>
        public string openid { get; set; }
    }
}
