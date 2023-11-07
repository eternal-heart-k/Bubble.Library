using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;

namespace Bubble.Library.Foundation
{
    public sealed class RequestContext
    {
        internal static readonly AsyncLocal<RequestContext> RequestContent = new();

        public static string GetCurrentUserId => RequestContent.Value?.UserId;

        public RequestContext(string operatorId, string remark = "")
        {
            OperatorId = operatorId;
            Remark = remark;
            Data = new Dictionary<string, string>();
        }

        public static bool IsExist() => RequestContent.Value is not null;

        public static RequestContext GetData()
        {
            return RequestContent.Value ??= new RequestContext(string.Empty);
        }

        public static void SetData(RequestContext requestContext)
        {
            RequestContent.Value = requestContext;
        }

        public static void SetCurrentRemark(string remark)
        {
            GetData().Remark = remark;
        }

        /// <summary>
        /// 入参的UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorId { get; }

        /// <summary>
        /// 操作备注
        /// </summary>
        public string Remark { get; private set; }

        /// <summary>
        /// 附加的数据信息
        /// </summary>
        [JsonInclude]
        public IDictionary<string, string> Data { get; private set; }
    }
}
