using Microsoft.AspNetCore.Builder;

namespace Bubble.Library.LibraryBuilder
{
    public static class ApplicationBuilderSwaggerExtensions
    {
        public static IApplicationBuilder UseLibrarySwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
