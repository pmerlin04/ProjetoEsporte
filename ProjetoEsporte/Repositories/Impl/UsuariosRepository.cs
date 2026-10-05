using Microsoft.EntityFrameworkCore;
using ProjetoEsporte.Model;
using ProjetoEsporte.Model.Context;

namespace ProjetoEsporte.Repositories.Impl
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly MSSQLContext _context;

        public UsuariosRepository(MSSQLContext context)
        {
            _context = context;
        }
        public async Task<List<Usuarios>> FindAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> FindById(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");

            }
            return usuario;
        }

        public async Task<Usuarios> Create(Usuarios usuarios)
        {
            var createdUsuario = new Usuarios
            {
                EmailUsuario = usuarios.EmailUsuario,
                IdUsuario = usuarios.IdUsuario,
                NomeUsuario = usuarios.NomeUsuario
            };

            await _context.Usuarios.AddAsync(createdUsuario);
            await _context.SaveChangesAsync();
            return createdUsuario;
        }

        public async Task<Usuarios> Update(int id, Usuarios usuarios)
        {
            var usuarioExisting = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuarioExisting == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {usuarios.IdUsuario} não encontrado.");
            }

            usuarioExisting.NomeUsuario = usuarios.NomeUsuario;
            usuarioExisting.EmailUsuario = usuarios.EmailUsuario;

             _context.Entry(usuarioExisting);
            await _context.SaveChangesAsync();
            return usuarios;
        }
        public void Delete(int id)
        {
           var usuarioExisting = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioExisting == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");
            }
            _context.Usuarios.Remove(usuarioExisting);
            _context.SaveChanges();
        }
    }
}
