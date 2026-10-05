using ProjetoEsporte.Model;
using ProjetoEsporte.Repositories;

namespace ProjetoEsporte.Services.Implementations
{
    public class QuadrasServicesImpl : IQuadrasServices
    {
        private IQuadrasRepository _repository;

        public QuadrasServicesImpl(IQuadrasRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Quadras>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Quadras> FindById(int id)
        {
            return await _repository.FindById(id);
        }
        public async Task<Quadras> Create(Quadras quadras)
        {
            return await _repository.Create(quadras);
        }

        public async Task<Quadras> Update(int id, Quadras quadras)
        {
            return await _repository.Update(id, quadras);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
