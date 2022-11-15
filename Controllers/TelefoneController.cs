using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {

    [Route("v1/api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase {

        private readonly ITelefoneRepository repository;

        public TelefoneController(ITelefoneRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Telefone>>> EncontrarTodos() {
            List<Telefone> telefones  = await repository.EncontrarTodos();
            if (telefones.Count == 0) {
                return NotFound($"Não foi possivel encontrar telefones.");
            }

            return Ok(telefones);
        }

        [HttpGet("ddd/{ddd}")]
        public async Task<ActionResult<List<Telefone>>> EncontrarPorDdd([FromRoute] int ddd) { 
            List<Telefone> telefones = await repository.EncontrarPorDdd(ddd);
            if (telefones.Count == 0) {
                return NotFound($"Não foi possivel encontrar telefones com o DDD {ddd}.");
            }

            return Ok(telefones);
        }

        [HttpGet("numero/{numero}")]
        public async Task<ActionResult<Telefone>> EncontrarPorNumero([FromRoute] int numero) {
            Telefone telefone = await repository.EncontrarPorNumero(numero);
            if (telefone == null) { 
                return NotFound($"Não foi possivel encontrar o telefone com o número {numero}.");
            }

            return Ok(telefone);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> EncontrarPorId([FromRoute] int id) { 
            Telefone telefone = await repository.EncontrarPorId(id);
            if (telefone == null) { 
                return NotFound($"Não foi possivel encontrar o telefone com o id {id}.");
            }

            return Ok(telefone);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adicionar([FromBody] Telefone telefone) { 
            bool resultado = await repository.Adicionar(telefone);
            if (!resultado) { 
                return BadRequest($"Não foi possivel adiciona o telefone.");
            }

            return Ok($"O telefone foi adicionado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Atualizar([FromRoute] int id, 
            [FromBody] Telefone telefone) {
            bool result = await repository.Atualizar(id, telefone);
            if (!result) {
                return BadRequest($"Não foi possivel atualizar o telefone com o id {id}.");
            }

            return Ok($"Telefone com o id {id} atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remover([FromRoute] int id) {
            bool resultado = await repository.Remover(id);
            if (!resultado) {
                return BadRequest($"Não foi possivel remover o telefone com o id {id}.");
            }

            return NoContent();
        }

    }

}