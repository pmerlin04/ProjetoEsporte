using Microsoft.EntityFrameworkCore;

namespace ProjetoEsporte.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios
        {
            get; set;
        }
        
        public DbSet<Quadras> Quadras
        {
            get; set;
        }

        public DbSet<Agendamentos> Agendamentos
        {
            get; set;
        }
    }
}
