using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension.Request;
using Bubble.Library.Foundation.Constant;
using Bubble.Library.Foundation.Dto.QQ;
using Bubble.Library.Foundation.Enum;
using System.Threading.Tasks;
using Bubble.Library.Extension;

namespace Bubble.Library.QQ
{
    /// <summary>
    /// QQ相关服务
    /// </summary>
    public class QQService : IQQService, ITransientDependency
    {
        private readonly IServiceClient _serviceClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceClient"></param>
        public QQService(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        /// <summary>
        /// 获取QQ授权链接地址
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string GetAuthorizationLink(QQAuthorizationCodeInputDto dto)
        {
            return _serviceClient.FormatUrl(QQConstant.AuthorizationCodeRequestUrl, dto, HttpRequestMethod.Get);
        }

        /// <summary>
        /// 通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<QQAccessTokenOutputDto> GetAccessTokenAsync(QQAccessTokenInputDto dto)
        {
            var result = await _serviceClient.GetAsync<QQAccessTokenOutputDto>(QQConstant.AccessTokenRequestUrl, dto);
            if (result.ErrorCode.HasValue && !result.ErrorMessage.IsNullOrWhiteSpace())
            {
                ThrowHelper.Throw(result.ErrorCode.Value, result.ErrorMessage);
            }
            return result;
        }

        /// <summary>
        /// 获取用户OpenID_OAuth2.0
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<QQOpenIdOutputDto> GetOpenIdAsync(QQOpenIdInputDto dto)
        {
            var result = await _serviceClient.GetAsync<QQOpenIdOutputDto>(QQConstant.OpenIdRequestUrl, dto);
            if (result.ErrorCode.HasValue && !result.ErrorMessage.IsNullOrWhiteSpace())
            {
                ThrowHelper.Throw(result.ErrorCode.Value, result.ErrorMessage);
            }
            return result;
        }

        /// <summary>
        /// 获取QQ用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<QQUserInfoOutputDto> GetUserInfoAsync(QQUserInfoInputDto dto)
        {
            var result = await _serviceClient.GetAsync<QQUserInfoOutputDto>(QQConstant.UserInfoRequestUrl, dto);
            if (result.Ret < 0)
            {
                ThrowHelper.Throw(result.Ret, result.Msg);
            }
            return result;
        }
    }
}
