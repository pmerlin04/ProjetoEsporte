using Microsoft.OpenApi;

namespace ProjetoEsporte.Configuration
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "REST API para HelpDesk";
        private static readonly string AppDescription = $"REST API RESTful developed by Pedro Merlin {AppName}";


        public static IServiceCollection AddOpenAPIConfig(
            this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Pedro",
                    Url = new Uri("https://pub.erudio.com.br/meus-cursos")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://pub.erudio.com.br/meus-cursos")
                }
            });
            return services;
        }
    }
}
