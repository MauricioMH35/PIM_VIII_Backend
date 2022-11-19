namespace PIM_VIII.Models.Builders {
    public class PessoaTelefoneBuilder {

        private int id;
        private int pessoaId;
        private Pessoa pessoa;
        private int telefoneId;
        private List<Telefone> telefones;

        public PessoaTelefoneBuilder Id(int id) {
            this.id = id; 
            return this;
        }

        public PessoaTelefoneBuilder PessoaId(int pessoaId) {
            this.pessoaId = pessoaId; 
            return this;
        }

        public PessoaTelefoneBuilder Pessoa(Pessoa pessoa) {
            this.pessoa = pessoa; 
            return this;
        }

        public PessoaTelefoneBuilder TelefoneId(int telefoneId) {
            this.telefoneId = telefoneId; 
            return this;
        }

        public PessoaTelefoneBuilder Telefones(List<Telefone> telefones) { 
            this.telefones = telefones; 
            return this; 
        }

        public PessoaTelefone Build() {
            return new PessoaTelefone(id, pessoaId, pessoa, telefoneId, telefones);
        }

    }
}
