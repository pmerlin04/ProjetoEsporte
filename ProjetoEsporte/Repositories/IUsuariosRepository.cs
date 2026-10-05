using ProjetoEsporte.Model;

namespace ProjetoEsporte.Repositories
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> FindById(int id);
        Task<List<Usuarios>> FindAll();
        Task<Usuarios> Create(Usuarios usuarios);
        Task<Usuarios> Update(int id, Usuarios usuarios);
        void Delete(int id);
    }
}
