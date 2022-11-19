using PIM_VIII.Models.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models {
    
    [Table("TB_PESSOAS")] 
    public class Pessoa {

        public int id { get; set; }
        public string nome { get; set; }
        public long cpf { get; set; }
        public int? enderecoId { get; set; }
        public virtual Endereco? endereco { get; set; }

        private Pessoa() {
        }

        public Pessoa(int id, string nome, long cpf, int? enderecoId, Endereco? endereco) {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.enderecoId = enderecoId;
            this.endereco = endereco;
        }

        public static PessoaBuilder Builder() {
            return new PessoaBuilder();
        }

    }

}
