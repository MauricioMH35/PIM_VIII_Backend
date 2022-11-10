using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {
    public class EnderecoRepository : IEnderecoRepository {

        private readonly BancoDadosContext context;

        public EnderecoRepository(BancoDadosContext context) {
            this.context = context;
        }

        public async Task<List<Endereco>> EncontrarTodos() {
            return await context.Enderecos.ToListAsync();
        }

        public async Task<List<Endereco>> EncontrarPorCep(string cep) {
            return await context.Enderecos.Where(x => x.cep == cep).ToListAsync();
        }

        public async Task<Endereco> EncontrarPorId(int id) {
            return await context.Enderecos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Adicionar(Endereco endereco) {
            List<Endereco> enderecos = await EncontrarPorCep(endereco.cep);
            foreach (Endereco e in enderecos) {
                if (e.numero == endereco.numero) {
                    return false;
                }
            }

            await context.Enderecos.AddAsync(endereco);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Atualizar(int id, Endereco endereco) {
            Endereco encontrado = await EncontrarPorId(id);
            if (encontrado.Equals(null)) {
                return false;
            }

            encontrado.logradouro = encontrado.logradouro != endereco.logradouro && endereco.logradouro != null ? endereco.logradouro : encontrado.logradour;
            encontrado.numero = encontrado.numero != endereco.numero ? endereco.numero : encontrado.numero;
            encontrado.cep = encontrado.cep != endereco.cep && endereco.cep != null ? endereco.cep : encontrado.cep;
            encontrado.bairro = endereco.bairro != endereco.bairro && endereco.bairro != null ? endereco.bairro : encontrado.bairro;
            encontrado.cidade = encontrado.cidade != endereco.cidade && endereco.cidade != null ? endereco.cidade : encontrado.cidade;
            encontrado.estado = encontrado.estado != endereco.estado && endereco.estado  != null ? endereco.estado : encontrado.estado;

            context.Enderecos.Update(encontrado);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remover(int id) {
            Endereco endereco = await EncontrarPorId(id);
            if (endereco.Equals(null)) {
                return false;
            }

            context.Enderecos.Remove(endereco);
            await context.SaveChangesAsync();

            return true;
        }

    }

}
