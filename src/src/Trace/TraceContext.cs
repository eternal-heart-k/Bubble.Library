using System.Diagnostics;

namespace Bubble.Library.src.Trace
{
    public class TraceContext
    {
        private readonly bool _isTrace;

        private TraceContext(bool isTrace)
        {
            _isTrace = isTrace;
        }

        private static ActivityTraceId? TraceId => Activity.Current?.TraceId;

        public static string OperationId => TraceId?.ToHexString();

        public bool IsTrace => _isTrace;
    }
}
