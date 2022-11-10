using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models {

    [Table("TB_TELEFONES")]
    public class Telefone {
    
        public int id { get; set; }
        public int ddd { get; set; }
        public int numero { get; set; }
        public int? tipoId { get; set; }
        public TipoTelefone? tipo { get; set; }

        private Telefone() {
        }

        public Telefone(int id, int ddd, int numero, int? tipoId, TipoTelefone tipo) {
            this.id = id;
            this.ddd = ddd;
            this.numero = numero;
            this.tipoId = tipoId;
            this.tipo = tipo;
        }

    }

}
