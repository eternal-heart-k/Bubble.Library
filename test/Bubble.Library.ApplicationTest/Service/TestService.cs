using System.Threading.Tasks;
using Bubble.Library.ApplicationTest.Interface;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension;
using Bubble.Library.Extension.Operation;
using Bubble.Library.Foundation;

namespace Bubble.Library.ApplicationTest.Service
{
    public class TestService : ITestService, ITransientDependency
    {
        private readonly IOperationService _operationService;

        public TestService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task<string> TestOperationIdAsync(bool error)
        {
            await Task.Delay(0);

            var operationId = _operationService.GetOperationId();

            if (error)
            {
                ThrowHelper.Throw(10001, $"error {operationId}");
            }

            return operationId;
        }

        public async Task<string> TestRequestContextAsync(string userId, string remark)
        {
            await Task.Delay(0);

            var requestContext = RequestContext.GetData();

            requestContext.Data.Add("testkey", "testvalue");

            return $"UserId: {RequestContext.GetCurrentUserId} or {requestContext.UserId}, OperatorId: {requestContext.OperatorId}, remark: {requestContext.Remark}, data: {requestContext.Data.ToJsonString()}";
        }
    }
}
