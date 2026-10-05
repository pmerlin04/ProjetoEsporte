using Microsoft.EntityFrameworkCore;
using ProjetoEsporte.Model.Context;

namespace ProjetoEsporte.Configuration
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration
           (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLConnection:MSSQLConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string 'MSSQLConnection' is not found");

            }

            services.AddDbContext<MSSQLContext>(options =>
            options.UseMySQL(connectionString));
            return services;
        }
    }
}
