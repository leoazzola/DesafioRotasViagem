using DesafioRotasViagem.Application.Interfaces;
using DesafioRotasViagem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRotasViagem.API.Controllers
{
    [ApiController]
    [Route("rotas")]
    public class RoutesController : ControllerBase
    {
        private readonly IRotasViagemService _rotasService;

        public RoutesController(IRotasViagemService rotasService)
        {
            _rotasService = rotasService;
        }

        [HttpGet("obter-rotas")]
        [ProducesResponseType(typeof(IEnumerable<Rota>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRotas()
        {
            return Ok(await _rotasService.GetRotasAsync());
        }

        [HttpGet("obter-rota/{id}")]
        [ProducesResponseType(typeof(Rota), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Rota>> GetRotasById(int id)
        {
            return Ok(await _rotasService.GetRotasByIdAsync(id));
        }

        [HttpGet("obter-melhor-rota")]
        [ProducesResponseType(typeof(Rota), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Rota>> GetMelhorRota(string origem, string destino)
        {
            var route = await _rotasService.GetMelhorRotaAsync(origem, destino);
            if (route == null)
                return NotFound("Rota não encontrada.");

            return Ok(route);
        }

        [HttpPost("incluir-rota")]
        [ProducesResponseType(typeof(Rota), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddRota([FromBody] Rota route)
        {
            await _rotasService.AddRotaAsync(route);
            return CreatedAtAction(nameof(GetRotas), new { id = route.Id }, route);
        }

        [HttpPut("atualizar-rota/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] Rota route)
        {
            if (id != route.Id)
                return BadRequest();

            await _rotasService.UpdateRotaAsync(route);
            return Ok();
        }

        [HttpDelete("excluir-rota/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _rotasService.DeleteRotaAsync(id);
            return Ok();
        }
    }
}
