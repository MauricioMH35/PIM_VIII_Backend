using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {
    public interface IEnderecoRepository {

        Task<List<Endereco>> EncontrarTodos();
        Task<List<Endereco>> EncontrarPorCep(string cep);
        Task<Endereco> EncontrarPorId(int id);
        Task<bool> Adicionar(Endereco endereco);
        Task<bool> Atualizar(int id, Endereco endereco);
        Task<bool> Remover(int id);

    }
}
