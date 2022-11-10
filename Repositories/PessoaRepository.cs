using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {
    public class PessoaRepository : IPessoaRepository {

        private BancoDadosContext context;

        public PessoaRepository(BancoDadosContext context) {
            this.context = context;
        }

        public async Task<List<Pessoa>> EncontrarTodos() {
            return await context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> EncontrarPorId(int id) {
            return await context.Pessoas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Pessoa> EncontrarPorCpf(long cpf) {
            return await context.Pessoas.FirstOrDefaultAsync(x => x.cpf == cpf);
        }

        public async Task<bool> Adicionar(Pessoa pessoa) {
            if (await EncontrarPorCpf(pessoa.cpf) != null) {
                return false;
            }

            await context.Pessoas.AddAsync(pessoa);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Atualizar(int id, Pessoa pessoa) {
            Pessoa encontrada = await EncontrarPorId(id);
            if (encontrada == null) {
                throw new Exception($"A pessoa com o id:{id} não foi encontrada.");
            }

            encontrada.nome = encontrada.nome != pessoa.nome ? pessoa.nome : encontrada.nome;
            encontrada.cpf = encontrada.cpf != pessoa.cpf ? pessoa.cpf : encontrada.cpf;
            encontrada.enderecoId = encontrada.enderecoId != pessoa.enderecoId && pessoa.enderecoId != null ? pessoa.enderecoId : encontrada.enderecoId;
            encontrada.endereco = encontrada.endereco != pessoa.endereco && pessoa.endereco != null ? pessoa.endereco : encontrada.endereco;
            
            context.Pessoas.Update(encontrada);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remover(int id) {
            Pessoa encontrada = await EncontrarPorId(id);
            if (encontrada == null) {
                throw new Exception($"Não foi possivel encontrar pelo id:{id} a pessoa procurada.");
            }

            context.Pessoas.Remove(encontrada);
            await context.SaveChangesAsync();

            return true;
        }

    }
}
