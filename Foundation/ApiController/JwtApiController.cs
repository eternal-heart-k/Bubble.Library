using Microsoft.AspNetCore.Authorization;

namespace Bubble.Library.Foundation.ApiController
{
    /// <summary>
    /// Jwt API控制器基类
    /// </summary>
    [Authorize]
    public class JwtApiController : ApiBaseController
    {
    }
}
