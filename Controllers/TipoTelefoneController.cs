using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoTelefoneController : ControllerBase {

        private readonly ITipoTelefoneRepository repository;

        public TipoTelefoneController(ITipoTelefoneRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoTelefone>>> EncontrarTodos() {
            List<TipoTelefone> telefones = await repository.EncontrarTodos();
            if (telefones == null) {
                return NotFound($"Não foi possivel encontrar tipos de telefone.");
            }

            return Ok(telefones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTelefone>> EncontrarPorId([FromRoute] int id) { 
            TipoTelefone telefone = await repository.EncontrarPorId(id);
            if (telefone == null) { 
                return NotFound($"Não foi possivel encontrar o tipo de telefone com o id {id}.");
            }

            return Ok(telefone);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adicionar([FromBody] TipoTelefone tipoTelefone) {
            bool resultado = await repository.Adicionar(tipoTelefone);
            if (!resultado) {
                return BadRequest($"Não foi possivel adicionar o tipo de telefone.");
            }

            return Ok("Telefone adicionado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Atualizar([FromRoute] int id,
            [FromBody] TipoTelefone tipoTelefone) { 
            bool resultado = await repository.Atualizar(id, tipoTelefone);
            if (!resultado) {
                return BadRequest($"Não foi possivel atualizar o tipo de telefone com o id {id}.");
            }

            return Ok("Telefone atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remover([FromRoute] int id) {
            bool resultado = await repository.Remover(id);
            if (!resultado) {
                return BadRequest($"Não foi possivel remover o tipo de telefone com o id {id}.");
            }

            return NoContent();
        }

    }

}
