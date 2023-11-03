using Bubble.Library.DependencyInjection;
using System.Diagnostics;

namespace Bubble.Library.Extension.Operation
{
    public class OperationService : IOperationService, ISingletonDependency
    {
        public string GetOperationId() => Activity.Current?.TraceId.ToHexString();

        public string GetParentOperationId() => Activity.Current?.ParentId ?? GetOperationId();
    }
}
