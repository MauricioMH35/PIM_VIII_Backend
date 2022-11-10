using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {
    public interface ITelefoneRepository {

        Task<List<Telefone>> EncontrarTodos();
        Task<List<Telefone>> EncontrarPorDdd(int ddd);
        Task<Telefone> EncontrarPorNumero(int numero);
        Task<Telefone> EncontrarPorId(int id);
        Task<bool> Adicionar(Telefone telefone);
        Task<bool> Atualizar(int id, Telefone telefone);
        Task<bool> Remover(int id);

    }
}
