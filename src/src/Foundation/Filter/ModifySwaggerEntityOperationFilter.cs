using Bubble.Library.Foundation.Attribute;
using Bubble.Library.Foundation.Dto.Common;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bubble.Library.Foundation.Filter
{
    /// <summary>
    /// swagger response preview
    /// </summary>
    public class ModifySwaggerEntityOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out var methodInfo);

            var actualReturnType = context.MethodInfo.ReturnType.Name == "Task`1"
                ? context.MethodInfo.ReturnType.GenericTypeArguments.FirstOrDefault()
                : context.MethodInfo.ReturnType;
            if (actualReturnType is { Name: not ("ApiResult`1" or "ApiResult") })
            {
                var isNotWrapResult = methodInfo.IsDefined(typeof(NotWarpApiResultAttribute));
                var wrapApiResultReturnType =
                    isNotWrapResult
                        ? actualReturnType
                        : actualReturnType == typeof(void) || actualReturnType == typeof(Task)
                            ? typeof(ApiResult)
                            : typeof(ApiResult<>).MakeGenericType(actualReturnType);

                operation?.Responses?.Remove("200");
                operation?.Responses?.Add("200",
                    new OpenApiResponse
                    {
                        Description = "Success",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            {
                                "application/json", new OpenApiMediaType
                                {
                                    Schema = context.SchemaGenerator.GenerateSchema(wrapApiResultReturnType,
                                        context.SchemaRepository)
                                }
                            }
                        }
                    });
            }
        }
    }
}
