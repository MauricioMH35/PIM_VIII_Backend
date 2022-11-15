using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {
    
    [ApiController]
    [Route("/v1/api/[controller]")]
    public class EnderecoController : ControllerBase {

        private readonly IEnderecoRepository repository;
        private readonly IViaCepRepository viaCepRepository;

        public EnderecoController(IEnderecoRepository repository, IViaCepRepository viaCepRepository) {
            this.repository = repository;
            this.viaCepRepository = viaCepRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> EncontrarTodos() {
            List<Endereco> enderecos = await repository.EncontrarTodos();
            if (enderecos.Count == 0) {
                return NotFound($"Não foi possível encontrar endereços.");
            }

            return Ok(enderecos);
        }

        [HttpGet("cep/{cep}")]
        public async Task<ActionResult<List<Endereco>>> EncontrarPorCep([FromRoute] string cep) {
            List<Endereco> enderecos = await repository.EncontrarPorCep(cep);
            if (enderecos.Count == 0) { 
                return NotFound($"Não foi possivel encontrar endereços com o CEP {cep}.");
            }

            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> EncontrarPorId([FromRoute] int id) {
            Endereco endereco = await repository.EncontrarPorId(id);
            if (endereco == null) {
                return NotFound($"Não foi possivel encontrar o endereço pelo id {id}.");
            }

            return Ok(endereco);
        }

        [HttpGet("pesquisar/cep/{cep}/numero/{numero}")]
        public async Task<ActionResult<Endereco>> PesquisarCep([FromRoute] string cep,
            [FromRoute] int numero) {
            ViaCep viaCep = await viaCepRepository.PesquisaCep(cep);
            if (viaCep == null) {
                return NotFound($"Não foi possivel encontrar o endereço via cep {cep}.");
            }

            return Ok(viaCep.Parse(numero));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adicionar([FromBody] Endereco endereco) {
            bool resultado = await repository.Adicionar(endereco);
            if (!resultado) {
                return BadRequest($"Não foi possivel adicionar o endereço.");
            }

            return Ok("Endereço adicionado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Atualizar([FromRoute] int id, [FromBody] Endereco endereco) {
            bool resultado = await repository.Atualizar(id, endereco);
            if (!resultado) {
                return BadRequest($"Não foi possivel atualizar o endereco com o id {id}.");
            }

            return Ok($"Endereço com o id {id} atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remover([FromRoute] int id) { 
            bool resultado = await repository.Remover(id);
            if (!resultado) {
                return BadRequest($"Não foi possivel remover o endereço com o id {id}.");
            }

            return NoContent();
        }

    }

}
