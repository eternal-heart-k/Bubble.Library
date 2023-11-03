using System.Threading.Tasks;
using Bubble.Library.Foundation.Dto.QQ;

namespace Bubble.Library.QQ
{
    /// <summary>
    /// QQ相关
    /// </summary>
    public interface IQQService
    {
        /// <summary>
        /// 获取QQ授权链接地址
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        string GetAuthorizationLink(QQAuthorizationCodeInputDto dto);

        /// <summary>
        /// 通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<QQAccessTokenOutputDto> GetAccessTokenAsync(QQAccessTokenInputDto dto);

        /// <summary>
        /// 获取用户OpenID_OAuth2.0
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<QQOpenIdOutputDto> GetOpenIdAsync(QQOpenIdInputDto dto);

        /// <summary>
        /// 获取QQ用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<QQUserInfoOutputDto> GetUserInfoAsync(QQUserInfoInputDto dto);
    }
}
