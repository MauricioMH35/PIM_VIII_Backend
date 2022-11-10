using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models {

    [Table("TB_TIPOS_TELEFONES")]
    public class TipoTelefone {

        public int id { get; set; }
        public string tipo { get; set; }

        private TipoTelefone() {
        }

        public TipoTelefone(int id, string? tipo) {
            this.id = id;
            this.tipo = tipo;
        }

    }

}
