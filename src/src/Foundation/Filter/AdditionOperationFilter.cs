using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bubble.Library.Foundation.Filter
{
    /// <summary>
    /// swagger addition query param
    /// </summary>
    public class AdditionOperationFilter : IOperationFilter
    {
        private static readonly IList<OpenApiParameter> AttachOpenApiParameters = new List<OpenApiParameter>
        {
            new()
            {
                Description = "操作人Id",
                Name = "OperatorId",
                Required = false,
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                }
            },
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context is null) return;

            if (operation?.Parameters is not null)
            {
                foreach (var attachOpenApiParameter in AttachOpenApiParameters)
                {
                    if (operation.Parameters.All(x => x.Name != attachOpenApiParameter.Name))
                        operation.Parameters.Add(attachOpenApiParameter);
                }
            }
        }
    }
}
