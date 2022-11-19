namespace PIM_VIII.Models.Builders {
    public class PessoaBuilder {
        
        private int id;
        private string nome;
        private long cpf;
        private int enderecoId;
        private Endereco endereco;

        public PessoaBuilder Id(int id) { 
            this.id = id; 
            return this; 
        }

        public PessoaBuilder Nome(string nome) {
            this.nome = nome; 
            return this; 
        }

        public PessoaBuilder Cpf(long cpf) {
            this.cpf = cpf; 
            return this; 
        }

        public PessoaBuilder EnderecoId(int enderecoId) {
            this.enderecoId = enderecoId; 
            return this; 
        }

        public PessoaBuilder Endereco(Endereco endereco) {
            this.endereco = endereco; 
            return this; 
        }

        public Pessoa Build() {
            return new Pessoa(id, nome, cpf, enderecoId, endereco);
        }

    }
}
