using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {

    [ApiController]
    [Route("v1/api/[controller]")]
    public class PessoaTelefoneController : ControllerBase {

        private readonly IPessoaTelefoneRepository repository;

        public PessoaTelefoneController(IPessoaTelefoneRepository repository) {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> EncontrarPorId([FromRoute] int id) { 
            PessoaTelefone pessoaTelefone = await repository.EncontrarPorId(id);
            if (pessoaTelefone == null) { 
                return NotFound($"Não foi possivel encontrar o telefone da pessoa com o id {id}.");
            }

            return Ok(pessoaTelefone);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adicionar([FromBody] PessoaTelefone pessoaTelefone) { 
            bool resultado = await repository.Adicionar(pessoaTelefone);
            if (!resultado) { 
                return BadRequest($"Não foi possivel adiciona o telefone a pessoa.");
            }

            return Ok($"O telefone foi adicionado com sucesso para a pessoa.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remover([FromRoute] int id) {
            bool resultado = await repository.Remover(id);
            if (!resultado) {
                return BadRequest($"Não foi possivel remover o telefone da pessoa com o id {id}.");
            }

            return NoContent();
        }

    }

}