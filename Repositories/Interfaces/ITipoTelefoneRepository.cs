using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {

    public interface ITipoTelefoneRepository {

        Task<List<TipoTelefone>> EncontrarTodos();
        Task<TipoTelefone> EncontrarPorId(int id);
        Task<bool> Adicionar(TipoTelefone tipoTelefone);
        Task<bool> Atualizar(int id, TipoTelefone tipoTelefone);
        Task<bool> Remover(int id);

    }

}