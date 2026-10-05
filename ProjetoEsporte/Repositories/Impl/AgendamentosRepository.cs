using Microsoft.EntityFrameworkCore;
using ProjetoEsporte.Db.DTO;
using ProjetoEsporte.Model;
using ProjetoEsporte.Model.Context;

namespace ProjetoEsporte.Repositories.Impl
{
    public class AgendamentosRepository : IAgendamentosRepository
    {
        private readonly MSSQLContext _context;

        public AgendamentosRepository(MSSQLContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamentos>> FindAll()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<Agendamentos> FindById(int id)
        {
            var existingAgendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.IdAgendamento == id);
            if(existingAgendamento == null)
            {
                throw new KeyNotFoundException($"Agendamento com id {id} não encontrado");
            }

            return existingAgendamento;
        }


        public async Task<Agendamentos> Create(Agendamentos agendamento)
        {
            
            var createdAgendamento = new Agendamentos
            {
                EmailUsuario = agendamento.EmailUsuario,
                IdQuadra = agendamento.IdQuadra,
                DiaSemana = agendamento.DiaSemana,
                HorarioInicio = agendamento.HorarioInicio,
                HorarioFinal = agendamento.HorarioFinal,
                StatusAgendamento = "Solicitado"

            };

            await _context.Agendamentos.AddAsync(createdAgendamento);
            await _context.SaveChangesAsync();
            return createdAgendamento;
        }


        public async Task<Agendamentos> UpdateStatusAgendamento(int id, AgendamentoDTO agendamentoDTO)
        {
            var existingAgendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.IdAgendamento == id);
            if(existingAgendamento == null)
            {
                throw new KeyNotFoundException($"Agendamento com id {id} não encontrado");
            }

            existingAgendamento.StatusAgendamento = agendamentoDTO.StatusAgendamento;

            _context.Entry(existingAgendamento);
            await _context.SaveChangesAsync();
            return existingAgendamento;


        }


        public void Delete(int id)
        {
            var existingAgendamento =  _context.Agendamentos.FirstOrDefault(a => a.IdAgendamento == id);
            if (existingAgendamento == null)
            {
                throw new KeyNotFoundException($"Agendamento com id {id} não encontrado");
            }

            _context.Remove(existingAgendamento);
            _context.SaveChanges();
        }

        
        public async Task<List<DateTime>> HorariosDisponiveis(DateTime data, int id)
        {
            var existingQuadra = await _context.Quadras.FirstOrDefaultAsync(q => q.IdQuadra == id);
            if(existingQuadra == null)
            {
                throw new KeyNotFoundException($"Quadra com id {id} não encontrada");
            }


            DateTime horaInicioFunc = data.Date.AddHours(8);
            DateTime horaFinalFunc = data.Date.AddHours(22);
            List<DateTime> horarios = new List<DateTime>();
            for(horaInicioFunc = data.Date.AddHours(8); horaInicioFunc <= horaFinalFunc; horaInicioFunc = horaInicioFunc.AddHours(1))
            {
                //aqui ele puxa os horarios do DIA passado pelo usuário e de acordo com a hora atual
                //por exemplo: se AGORA for 08:00:00, ele retorna os horários de 09:00:00 pra frente
                if(horaInicioFunc.Date == data && horaInicioFunc > DateTime.Now)
                {
                    horarios.Add(horaInicioFunc);
                }
                
            }

            //aqui ele está puxando os horarios de acordo com o Id da Quadra, a Data e o status = "Aprovado"
            var horariosOcupados = await _context.Agendamentos

                .Where(agendamento => agendamento.IdQuadra == id &&
                       agendamento.HorarioInicio.Date == data.Date && (agendamento.StatusAgendamento == "Aprovado" || agendamento.StatusAgendamento == "Pendente"))

                .Select(agendamento => agendamento.HorarioInicio)

                .ToListAsync();

            //aqui ele puxa os horários q NÃO contém o statusAgendamento = "Aprovado"
            var horariosLivres = horarios.Where(hora => !horariosOcupados.Contains(hora)).ToList();

            return horariosLivres;
        }


        public async Task<List<DateTime>> HorariosPendentes (DateTime data, int id)
        {
            var horariosOcupados = await _context.Agendamentos

               .Where(agendamento => agendamento.IdQuadra == id &&
                      agendamento.HorarioInicio.Date == data.Date && (agendamento.StatusAgendamento == "Aprovado" || agendamento.StatusAgendamento == "Pendente"))

               .Select(agendamento => agendamento.HorarioInicio)

               .ToListAsync();

            return horariosOcupados;
        }


        public async Task<Agendamentos> ReservarHorario (DateTime data, int id, Agendamentos agendamento)
        {
            var existingQuadra = await _context.Quadras.FirstOrDefaultAsync(q => q.IdQuadra == id);
            if (existingQuadra == null)
            {
                throw new KeyNotFoundException($"Quadra com id {id} não encontrada");
            }

            var existingAgendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.HorarioInicio == data && a.IdQuadra == id);
            if(existingAgendamento != null)
            {
                throw new Exception("Este horário acabou de ser agendado.");
            }

            var createdAgendamento = new Agendamentos
            {
                EmailUsuario = agendamento.EmailUsuario,
                IdQuadra = id, //id da quadra passado no método
                DiaSemana = agendamento.DiaSemana,
                HorarioInicio = data,
                HorarioFinal = data.AddHours(1), 
                StatusAgendamento = "Pendente"
            };

            await _context.AddAsync(createdAgendamento);
            await _context.SaveChangesAsync();
            return createdAgendamento;

        }


        public async Task<Agendamentos> CancelarHorario (int id, AgendamentoDTO agendamento)
        {
            var existingAgendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.IdAgendamento == id);
            if(existingAgendamento == null)
            {
                throw new KeyNotFoundException($"Agendamento com id {id} não existe");
            }

            existingAgendamento.StatusAgendamento = agendamento.StatusAgendamento;

            _context.Entry(existingAgendamento);
            await _context.SaveChangesAsync();
            return (existingAgendamento);

        }






    }
}
