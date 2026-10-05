using Microsoft.OpenApi;

namespace ProjetoEsporte.Configuration
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "REST API para HelpDesk";
        private static readonly string AppDescription = $"REST API RESTful developed by Pedro Merlin {AppName}";

        public static IServiceCollection AddSwaggerConfig(
        this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {

                    Title = AppName,
                    Version = "v1",
                    Description = AppDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro",
                        Url = new Uri("https://pub.erudio.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://pun.erudio.com.br/meus-cursos")
                    }
                });
                options.CustomSchemaIds(type => type.FullName);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSpecification(
            this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });
            return app;
        }
    }
}
