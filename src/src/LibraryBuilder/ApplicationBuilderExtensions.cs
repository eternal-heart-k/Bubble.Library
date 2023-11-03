using Bubble.Library.Extension;
using Microsoft.AspNetCore.Builder;

namespace Bubble.Library.LibraryBuilder
{
    public static class ApplicationBuilderExtensions
    {
        public static void InitializeApplication(this WebApplication app, LibraryBuilderConfiguration libraryBuilderConfiguration)
        {
            if (!libraryBuilderConfiguration.CorsPolicyName.IsNullOrWhiteSpace())
                app.UseCors(libraryBuilderConfiguration.CorsPolicyName);

            app.UseForwardedHeaders();

            app.UseLibrarySwagger();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
