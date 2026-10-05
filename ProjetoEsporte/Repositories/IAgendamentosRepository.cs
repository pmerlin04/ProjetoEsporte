using ProjetoEsporte.Db.DTO;
using ProjetoEsporte.Model;

namespace ProjetoEsporte.Repositories
{
    public interface IAgendamentosRepository
    {
        Task <List<Agendamentos>> FindAll();
        Task <Agendamentos> FindById(int id);
        Task<Agendamentos> Create(Agendamentos agendamento);
        Task<Agendamentos> UpdateStatusAgendamento(int id, AgendamentoDTO agendamento);
        void Delete(int id);
        Task<List<DateTime>> HorariosDisponiveis(DateTime data, int id);
        Task<List<DateTime>> HorariosPendentes(DateTime data, int id);
        Task<Agendamentos> ReservarHorario(DateTime data, int id, Agendamentos agendamento);
        Task<Agendamentos> CancelarHorario(int id, AgendamentoDTO agendamento);
    }
}
