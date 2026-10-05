using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjetoEsporte.Model;
using ProjetoEsporte.Model.Context;

namespace ProjetoEsporte.Repositories.Impl
{
    public class QuadrasRepository : IQuadrasRepository
    {
        private readonly MSSQLContext _context;

        public QuadrasRepository(MSSQLContext context)
        {
            _context = context;
        }
        public async Task<List<Quadras>> FindAll()
        {
            return await _context.Quadras.ToListAsync();
        }

        public async Task<Quadras> FindById(int id)
        {
            var quadra = await _context.Quadras.FirstOrDefaultAsync(u => u.IdQuadra == id);
            if (quadra == null)
            {
                throw new KeyNotFoundException($"Quadra com ID {id} não encontrado.");

            }
            return quadra;
        }

        public async Task<Quadras> Create(Quadras quadras)
        {
            var createdQuadra = new Quadras
            {
                TipoQuadra = quadras.TipoQuadra,
                Bola = quadras.Bola
            };
            await _context.Quadras.AddAsync(createdQuadra);
            await _context.SaveChangesAsync();
            return createdQuadra;
        }

        public async Task<Quadras> Update(int id, Quadras quadra)
        {
            var quadraExisting = await _context.Quadras.FirstOrDefaultAsync(u => u.IdQuadra == id);
            if (quadraExisting == null)
            {
                throw new KeyNotFoundException($"Quadra com ID {quadra.IdQuadra} não encontrada.");
            }

            quadraExisting.TipoQuadra = quadra.TipoQuadra;
            quadraExisting.Bola = quadra.Bola;

            _context.Entry(quadraExisting);
            await _context.SaveChangesAsync();
            return quadra;
        }
        public void Delete(int id)
        {
            var existingQuadra = _context.Quadras.FirstOrDefault(u => u.IdQuadra == id);
            if (existingQuadra == null)
            {
                throw new KeyNotFoundException($"Quadra com ID {id} não encontrada.");
            }
            _context.Remove(existingQuadra);
            _context.SaveChanges();
        }
    }
}
