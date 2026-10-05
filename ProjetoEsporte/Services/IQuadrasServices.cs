using ProjetoEsporte.Model;

namespace ProjetoEsporte.Services
{
    public interface IQuadrasServices
    {
        Task<Quadras> FindById(int id);
        Task<List<Quadras>> FindAll();
        Task<Quadras> Create(Quadras quadras);
        Task<Quadras> Update(int id, Quadras quadras);
        void Delete(int id);
    }
}
