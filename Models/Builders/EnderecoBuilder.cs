namespace PIM_VIII.Models.Builders {
    public class EnderecoBuilder {

        private int id;
        private string? logradouro;
        private int numero;
        private string cep;
        private string? bairro;
        private string? cidade;
        private string? estado;

        public EnderecoBuilder Id(int id) { 
            this.id = id; 
            return this; 
        }

        public EnderecoBuilder Logradouro(string? logradouro) {
            this.logradouro = logradouro; 
            return this; 
        }

        public EnderecoBuilder Numero(int numero) {
            this.numero = numero; 
            return this; 
        }

        public EnderecoBuilder Cep(string cep) {
            this.cep = cep; 
            return this; 
        }

        public EnderecoBuilder Bairro(string? bairro) {
            this.bairro = bairro; 
            return this; 
        }

        public EnderecoBuilder Cidade(string? cidade) {
            this.cidade = cidade; 
            return this; 
        }

        public EnderecoBuilder Estado(string? estado) {
            this.estado = estado; 
            return this; 
        }

        public Endereco Build() {
            return new Endereco(id, logradouro, numero, cep, bairro, cidade, estado);
        }

    }
}
