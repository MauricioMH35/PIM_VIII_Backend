using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models {

    [Table("TB_ENDERECOS")]
    public class Endereco {

        public int id { get; set; }
        public string? logradouro { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }
        public string? bairro { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }

        private Endereco() { 
        
        }

        public Endereco(int id, string? logradouro, int numero, string cep, string? bairro, 
            string? cidade, string? estado) {
            this.id = id;
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
        }

    }

}
