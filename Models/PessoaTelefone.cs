using PIM_VIII.Models.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models {

    [Table("TB_PESSOAS_TELEFONES")]
    public class PessoaTelefone {

        public int id { get; set; }
        public int? pessoaId { get; set; }
        public Pessoa pessoa { get; set; }
        public int? telefoneId { get; set; }
        public List<Telefone> telefones { get; set; }

        private PessoaTelefone() {
        }

        public PessoaTelefone(int id, int pessoaId, Pessoa pessoa, int telefoneId, 
            List<Telefone> telefones) {
            this.id = id;
            this.pessoaId = pessoaId;
            this.pessoa = pessoa;
            this.telefoneId = telefoneId;
            this.telefones = telefones;
        }

        public static PessoaTelefoneBuilder Builder() {
            return new PessoaTelefoneBuilder();
        }

    }

}
