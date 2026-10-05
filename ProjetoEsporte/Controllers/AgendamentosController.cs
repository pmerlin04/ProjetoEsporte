using Microsoft.AspNetCore.Mvc;
using ProjetoEsporte.Db.DTO;
using ProjetoEsporte.Model;
using ProjetoEsporte.Repositories.Impl;
using ProjetoEsporte.Services;
using System.Security.Policy;

namespace ProjetoEsporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private IAgendamentosServices _agendamentoService;

        public AgendamentosController (IAgendamentosServices agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoService.FindAll();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var existingAgendamento = await _agendamentoService.FindById(id);
            if(existingAgendamento == null)
            {
                return BadRequest();
            }
            return Ok(existingAgendamento);
        }


        [HttpPost]
        public async Task<IActionResult> RealizarAgendamento([FromBody] Agendamentos agendamentos)
        {
            var createdAgendamento = await _agendamentoService.Create(agendamentos);
            return Ok(createdAgendamento);
        }


        [HttpPatch("AtualizarAgendamento")]
        public async Task<IActionResult> UpdateAgendamento(int id, [FromBody] AgendamentoDTO agendamentos)
        {
            var updatedAgendamento = await _agendamentoService.UpdateStatusAgendamento(id, agendamentos);
            return Ok(updatedAgendamento);
        }


        [HttpGet("HorariosDisponiveis")]
        public async Task<IActionResult> FreeTime(DateTime data, int id)
        {
            var resultado = await _agendamentoService.HorariosDisponiveis(data, id);
            

            return Ok(resultado);
        }

        [HttpGet("HorariosPendentes")]
        public async Task<IActionResult> PendentesTime(DateTime data, int id)
        {
            var resultado = await _agendamentoService.HorariosPendentes(data, id);

            return Ok(resultado);
        }

        [HttpPost("ReservarAgendamento")]
        public async Task<IActionResult> BookingTime ([FromQuery] DateTime data, int id, [FromBody] Agendamentos agendamento)
        {
            var resultado = await _agendamentoService.ReservarHorario(data, id, agendamento);

            return Ok(resultado);
        }

        [HttpPatch("CancelarAgendamento")]
        public async Task<IActionResult> CancelTime (int id, [FromBody] AgendamentoDTO agendamento)
        {
            var resultado = await _agendamentoService.CancelarHorario(id, agendamento);
            return Ok(resultado);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAgendamento = _agendamentoService.FindById(id);
            if(existingAgendamento == null)
            {
                return BadRequest();
            }

            _agendamentoService.Delete(id);
            return NoContent();
        }

        

    }
}
