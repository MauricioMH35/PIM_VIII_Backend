using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {

    [Route("v1/api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase {

        private readonly IPessoaRepository repository;

        public PessoaController(IPessoaRepository repository) { 
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> EncontrarTodos() {
            List<Pessoa> pessoas = await repository.EncontrarTodos();
            if (pessoas.Count == 0) {
                return NotFound($"Não foi possivel encontrar as pessoas.");
            }

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> EncontrarPorId(int id) {
            Pessoa pessoa = await repository.EncontrarPorId(id);
            if (pessoa.Equals(null)) {
                return NotFound($"Não foi possivel encontrar a pessoa com o id {id}.");
            }

            return Ok(pessoa);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<Pessoa>> EncontrarPorCpf(long cpf) {
            Pessoa pessoa = await repository.EncontrarPorCpf(cpf);
            if (pessoa.Equals(null)) {
                return NotFound($"Não foi possivel encontrar a pessoa com o CPF {cpf}.");
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adicionar([FromBody] Pessoa pessoa) {
            bool resultado = await repository.Adicionar(pessoa);
            if (!resultado) {
                return BadRequest($"Não foi possivel salvar a pessoa.");
            }

            return Ok("Pessoa adicionada com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Atualizar(int id, [FromBody] Pessoa pessoa) { 
            bool resultado = await repository.Atualizar(id, pessoa);
            if (!resultado) {
                return BadRequest($"Não foi possivel atualizar a pessoa com o id {id}.");
            }

            return Ok($"Dados da pessoa com o id {id} atualizados com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remover(int id) {
            bool resulatado = await repository.Remover(id);
            if (!resulatado) {
                return BadRequest($"Não foi possivel remover a pessoa com o id {id}.");
            }

            return NoContent();
        }

    }

}
