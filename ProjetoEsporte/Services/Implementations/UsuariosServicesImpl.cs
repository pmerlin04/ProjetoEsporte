using ProjetoEsporte.Model;
using ProjetoEsporte.Repositories;

namespace ProjetoEsporte.Services.Implementations
{
    public class UsuariosServicesImpl : IUsuariosServices
    {
        private IUsuariosRepository _repository;

        public UsuariosServicesImpl(IUsuariosRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Usuarios>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Usuarios> FindById(int id)
        {
            return await _repository.FindById(id);
        }
        public async Task<Usuarios> Create(Usuarios usuarios)
        {
            return await _repository.Create(usuarios);
        }

        public async Task<Usuarios> Update(int id, Usuarios usuarios)
        {
            return await _repository.Update(id, usuarios);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
