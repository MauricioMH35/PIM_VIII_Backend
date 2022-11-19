using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {
    public interface IPessoaTelefoneRepository {

        Task<PessoaTelefone> EncontrarPorId(int id);
        Task<bool> Adicionar(PessoaTelefone pessoaTelefone);
        Task<bool> Remover(int id);

    }
}
