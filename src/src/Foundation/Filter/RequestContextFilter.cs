using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension;
using Bubble.Library.Foundation.Dto.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Bubble.Library.Foundation.Filter
{
    public class RequestContextFilter : IActionFilter, ITransientDependency
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var query = context.HttpContext.Request.Query;
            RequestContext requestContext;
            if (!RequestContext.IsExist())
            {
                requestContext = GetRequestContext(query);
                RequestContext.SetData(requestContext);

                var activity = Activity.Current;
                if (activity is not null)
                {
                    if (!requestContext.OperatorId.IsNullOrWhiteSpace())
                        activity.SetBaggage(nameof(requestContext.OperatorId), requestContext.OperatorId);
                }
            }
            else requestContext = RequestContext.GetData();

            if (requestContext is not null)
            {
                foreach (var actionContextActionArgument in context.ActionArguments)
                {
                    var userId = ExtraUserId(actionContextActionArgument);
                    if (!userId.IsNullOrWhiteSpace())
                    {
                        requestContext.UserId = userId;
                        break;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // nothing
        }

        private static string ExtraUserId(KeyValuePair<string, object> parameterInfo)
        {
            if (parameterInfo.Value == null)
                return null;

            if (parameterInfo.Value is string && parameterInfo.Key.Equals("userId", StringComparison.OrdinalIgnoreCase))
            {
                return parameterInfo.Value.ToString();
            }

            if (parameterInfo.Value is IHaveUserId u)
            {
                return u.UserId;
            }

            return null;
        }

        private string GetValue(KeyValuePair<string, StringValues> item)
        {
            return item.Value.First();
        }

        private RequestContext GetRequestContext(IQueryCollection collection)
        {
            var operatorId = string.Empty;
            var remark = string.Empty;
            foreach (var item in collection)
            {
                if (item.Key.Equals("operatorId", StringComparison.OrdinalIgnoreCase))
                {
                    if (operatorId.IsNullOrWhiteSpace()) 
                        operatorId = GetValue(item);
                    continue;
                }

                if (item.Key.Equals("remark", StringComparison.OrdinalIgnoreCase))
                {
                    remark = GetValue(item);
                }
            }
            return new RequestContext(operatorId, remark);
        }
    }
}
