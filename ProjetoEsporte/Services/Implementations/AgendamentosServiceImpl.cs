using ProjetoEsporte.Db.DTO;
using ProjetoEsporte.Model;
using ProjetoEsporte.Repositories;

namespace ProjetoEsporte.Services.Implementations
{
    public class AgendamentosServiceImpl : IAgendamentosServices
    {
        private IAgendamentosRepository _repository;

        public AgendamentosServiceImpl(IAgendamentosRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Agendamentos>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Agendamentos> FindById(int id)
        {
            return await _repository.FindById(id);
        }
        public async Task<Agendamentos> Create(Agendamentos agendamento)
        {
            return await _repository.Create(agendamento);
        }

        public async Task<Agendamentos> UpdateStatusAgendamento(int id, AgendamentoDTO agendamento)
        {
            return await _repository.UpdateStatusAgendamento(id, agendamento);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<DateTime>> HorariosDisponiveis(DateTime data, int id)
        {
            return await _repository.HorariosDisponiveis(data, id);
        }
        public async Task<List<DateTime>> HorariosPendentes(DateTime data, int id)
        {
            return await _repository.HorariosPendentes(data, id);
        }
        public async Task<Agendamentos> ReservarHorario(DateTime data, int id, Agendamentos agendamento)
        {
            return await _repository.ReservarHorario(data, id, agendamento);
        }

        public async Task<Agendamentos> CancelarHorario(int id, AgendamentoDTO agendamento)
        {
            return await _repository.CancelarHorario(id, agendamento);
        }
    }
}
