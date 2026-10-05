using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProjetoEsporte.Model;
using ProjetoEsporte.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ProjetoEsporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosServices _services;

        public UsuariosController(IUsuariosServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _services.FindAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var usuario = await _services.FindById(id);
            if(usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuarios usuario)
        {
            var createdUsuario = await _services.Create(usuario);
            return Ok(createdUsuario);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] Usuarios usuario)
        {
            var existingUsuario = await _services.FindById(id);
            if(existingUsuario == null)
            {
                return BadRequest();
            }
            var updatedUsuario = _services.Update(id, usuario);
            return Ok(updatedUsuario);
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return NoContent();
        }
    }
}
