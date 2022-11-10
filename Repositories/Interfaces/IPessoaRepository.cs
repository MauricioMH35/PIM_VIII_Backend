using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {
    public interface IPessoaRepository {
        
        Task<List<Pessoa>> EncontrarTodos();
        Task<Pessoa> EncontrarPorId(int id);
        Task<Pessoa> EncontrarPorCpf(long cpf);
        Task<bool> Adicionar(Pessoa pessoa);
        Task<bool> Atualizar(int id, Pessoa pessoa);
        Task<bool> Remover(int id);

    }
}
