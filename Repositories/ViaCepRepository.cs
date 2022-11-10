using System.Text.Json;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Repositories {
    public class ViaCepRepository : IViaCepRepository {

        public async Task<ViaCep> PesquisaCep(string cep) {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            HttpClient cliente = new HttpClient();

            using var resposta = await cliente.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            resposta.EnsureSuccessStatusCode();

            if (resposta.Content is object &&
                resposta.Content.Headers.ContentType.MediaType == "application/json") {

                var stream = await resposta.Content.ReadAsStreamAsync();

                try {
                    return await JsonSerializer.DeserializeAsync<ViaCep>(
                        stream,
                        new JsonSerializerOptions {
                            IgnoreNullValues = true,
                            PropertyNameCaseInsensitive = true
                        }
                    );

                } catch (JsonException ex) {
                    throw new JsonException($"Não foi possivel realizar a consulta de " +
                        $"CEP {cep} usando a API ViaCep.");
                }

            } else {
                throw new Exception($"A resposta HTTP é invalida e não pode validar as informações" +
                    $" recuperadas.");
            }

            return null;
        }

    }

}