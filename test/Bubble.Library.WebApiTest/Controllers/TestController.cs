using Bubble.Library.ApplicationTest.Interface;
using Bubble.Library.Foundation.ApiController;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bubble.Library.WebApiTest.Controllers
{
    public class TestController : ApiBaseController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("operationid")]
        public Task<string> TestOperationIdAsync(bool error) => _testService.TestOperationIdAsync(error);

        [HttpGet("requestcontext")]
        public Task<string> TestRequestContextAsync(string userId, string remark) =>
            _testService.TestRequestContextAsync(userId, remark);
    }
}
