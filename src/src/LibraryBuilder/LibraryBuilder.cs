using Microsoft.AspNetCore.Builder;

namespace Bubble.Library.LibraryBuilder
{
    public static class LibraryBuilder
    {
        public static void InitializeApplication(string[] args, LibraryBuilderConfiguration libraryBuilderConfiguration)
        {
            libraryBuilderConfiguration ??= new LibraryBuilderConfiguration();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.Configuration();

            if (libraryBuilderConfiguration.ApolloConfiguration is not null)
                libraryBuilderConfiguration.ApolloConfiguration(builder);

            builder.Services.Configuration(libraryBuilderConfiguration);

            var app = builder.Build();

            app.InitializeApplication(libraryBuilderConfiguration);

            app.Run();
        }
    }
}
