using System.Threading.Tasks;
using Bubble.Library.ApplicationTest.Interface;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension;
using Bubble.Library.Extension.Operation;

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
    }
}
