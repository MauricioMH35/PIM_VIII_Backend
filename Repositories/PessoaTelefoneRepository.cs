using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {
    public class PessoaTelefoneRepository : IPessoaTelefoneRepository {

        private BancoDadosContext context;

        public PessoaTelefoneRepository(BancoDadosContext context) {
            this.context = context;
        }

        public async Task<PessoaTelefone> EncontrarPorId(int id) {
            return await context.PessoaTelefones.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Adicionar(PessoaTelefone pessoaTelefone) {
            await context.PessoaTelefones.AddAsync(pessoaTelefone);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(int id) {
            PessoaTelefone encontrada = await EncontrarPorId(id);
            if (encontrada == null) {
                throw new Exception($"Não foi possivel encontrar pelo id:{id}.");
            }

            context.PessoaTelefones.Remove(encontrada);
            await context.SaveChangesAsync();

            return true;
        }

    }
}
