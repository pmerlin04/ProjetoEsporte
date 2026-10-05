using Microsoft.AspNetCore.Mvc;
using ProjetoEsporte.Model;
using ProjetoEsporte.Repositories;
using ProjetoEsporte.Services;

namespace ProjetoEsporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuadrasController : ControllerBase
    {
        private IQuadrasServices _quadrasServices;

        public QuadrasController(IQuadrasServices quadrasServices)
        {
            _quadrasServices = quadrasServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quadras = await _quadrasServices.FindAll();
            return Ok(quadras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quadra = _quadrasServices.FindById(id);
            if(quadra == null)
            {
                return BadRequest();
            }

            return Ok(quadra);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quadras quadra)
        {
            var newQuadra = await _quadrasServices.Create(quadra);
            return Ok(newQuadra);
        }


        [HttpPatch]
        public async Task<IActionResult> Update(int id, [FromBody] Quadras quadra)
        {
            var updatedQuadra = await _quadrasServices.Update(id, quadra);
            return Ok(updatedQuadra);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _quadrasServices.Delete(id);
            return NoContent();
        }
    }
}
