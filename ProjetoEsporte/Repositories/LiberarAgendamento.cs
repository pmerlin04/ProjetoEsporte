using Microsoft.OpenApi;
using ProjetoEsporte.Db.DTO;
using ProjetoEsporte.Model.Context;

namespace ProjetoEsporte.Repositories
{
    public class LiberarAgendamento : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public LiberarAgendamento(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //enquanto a API não for desligada
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("O robô acordou e está limpando o banco!");
                //cria a conexão com o banco de dados
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<MSSQLContext>();

                    //onde o horário de agendamento já passou e o status ficou pendente
                    var horariosEsquecidos = _context.Agendamentos.Where(agendamento => agendamento.StatusAgendamento == "Pendente" &&
                    agendamento.HorarioInicio < DateTime.Now).ToList();

                    //muda o status para cancelado
                    foreach(var agendamento in horariosEsquecidos)
                    {
                        agendamento.StatusAgendamento = "Cancelado";
                    }

                    await _context.SaveChangesAsync();


                    var horariosCancelados = _context.Agendamentos.Where(agendamento => agendamento.StatusAgendamento == "Cancelado").ToList();
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                

            }
        }
    }
}
