using PIM_VIII.Models;

namespace PIM_VIII.Repositories.Interfaces {
    public interface IViaCepRepository {

        Task<ViaCep> PesquisaCep(string cep);

    }

}