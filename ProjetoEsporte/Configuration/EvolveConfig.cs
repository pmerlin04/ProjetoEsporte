using EvolveDb;
using MySql.Data.MySqlClient;
using Serilog;

namespace ProjetoEsporte.Configuration
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
          this IServiceCollection services,
          IConfiguration configuration,
          IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLConnection:MSSQLConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException("Connection string 'MSSQLConnection' is not found");

                }

                try
                {
                    using var evolveConnection = new MySqlConnection(connectionString);
                    var evolve = new Evolve(
                        evolveConnection,
                        msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (Exception e)
                {
                    Log.Error(e, "An error occured while migrating the database.");
                    throw;
                }
            }

            return services;
        }
    }
}
