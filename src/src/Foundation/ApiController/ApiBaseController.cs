using Bubble.Library.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace Bubble.Library.Foundation.ApiController
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBaseController : ControllerBase, ITransientDependency
    {
    }
}
