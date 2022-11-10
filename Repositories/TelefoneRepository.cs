using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {

    public class TelefoneRepository : ITelefoneRepository {

        private readonly BancoDadosContext context;

        public TelefoneRepository(BancoDadosContext context) {
            this.context = context;
        }

        public async Task<List<Telefone>> EncontrarTodos() {
            return await context.Telefones.ToListAsync();
        }

        public async Task<List<Telefone>> EncontrarPorDdd(int ddd) {
            return await context.Telefones.Where(x => x.ddd == ddd).ToListAsync();
        }

        public async Task<Telefone> EncontrarPorNumero(int numero) {
            return await context.Telefones.FirstOrDefaultAsync(x => x.numero == numero);
        }

        public async Task<Telefone> EncontrarPorId(int id) {
            return await context.Telefones.FirstAsync(x => x.id == id);
        }

        public async Task<bool> Adicionar(Telefone telefone) {
            if (await EncontrarPorNumero(telefone.numero) != null) {
                return false;
            }

            await context.Telefones.AddAsync(telefone);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Atualizar(int id, Telefone telefone) {
            Telefone encontrado = await EncontrarPorId(id);
            if (encontrado == null) {
                return false;
            }

            encontrado.ddd = encontrado.ddd != telefone.ddd && telefone.ddd != null ? telefone.ddd : encontrado.ddd;
            encontrado.numero = encontrado.numero != telefone.numero && telefone.numero != null ? telefone.numero : encontrado.numero;
            encontrado.tipoId = encontrado.tipoId != telefone.tipoId && telefone.tipoId != null ? telefone.tipoId : encontrado.tipoId;
            encontrado.tipo = encontrado.tipo != telefone.tipo && telefone.tipo != null ? telefone.tipo : encontrado.tipo;

            context.Telefones.Update(encontrado);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remover(int id) {
            Telefone telefone = await EncontrarPorId(id);
            if (telefone != null) {
                return false;
            }

            context.Telefones.Remove(telefone);
            return true;
        }

    }

}