using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {

    public class TipoTelefoneRepository : ITipoTelefoneRepository {

        private readonly BancoDadosContext context;

        public TipoTelefoneRepository(BancoDadosContext context) {
            this.context = context;
        }

        public async Task<List<TipoTelefone>> EncontrarTodos() {
            return await context.TipoTelefones.ToListAsync();
        }

        public async Task<TipoTelefone> EncontrarPorId(int id) {
            return await context.TipoTelefones.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Adicionar(TipoTelefone tipoTelefone) {
            TipoTelefone? encontrado = await context.TipoTelefones
                .FirstOrDefaultAsync(x => x.tipo == tipoTelefone.tipo);
            if (encontrado != null) {
                return false;
            }

            await context.TipoTelefones.AddAsync(tipoTelefone);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Atualizar(int id, TipoTelefone tipoTelefone) {
            TipoTelefone encontrado = await EncontrarPorId(id);
            if (encontrado.Equals(null)) {
                return false;
            }

            encontrado.tipo = encontrado.tipo != tipoTelefone.tipo && tipoTelefone.tipo != null ? tipoTelefone.tipo : encontrado.tipo;

            context.TipoTelefones.Update(encontrado);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(int id) {
            TipoTelefone tipoTelefone = await EncontrarPorId(id);
            if (tipoTelefone.Equals(null)) {
                return false;
            }

            context.TipoTelefones.Remove(tipoTelefone);
            await context.SaveChangesAsync();
            return true;
        }

    }

}