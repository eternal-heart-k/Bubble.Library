using Bubble.Library.Foundation.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Bubble.Library.Foundation.ApiController
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiResponse]
    public class ApiBaseController : ControllerBase
    {
    }
}
