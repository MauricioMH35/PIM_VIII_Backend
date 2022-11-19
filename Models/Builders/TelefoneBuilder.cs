namespace PIM_VIII.Models.Builders {
    public class TelefoneBuilder {

        private int id;
        private int ddd;
        private int numero;
        private int? tipoId;
        private TipoTelefone? tipo;

        public TelefoneBuilder Id(int id) {
            this.id = id; 
            return this; 
        }

        public TelefoneBuilder Ddd(int ddd) {
            this.ddd = ddd; 
            return this; 
        }

        public TelefoneBuilder Numero(int numero) {
            this.numero = numero; 
            return this; 
        }

        public TelefoneBuilder TipoId(int? tipoId) {
            this.tipoId = tipoId; 
            return this; 
        }

        public TelefoneBuilder Tipo(TipoTelefone? tipo) { 
            this.tipo = tipo; 
            return this; 
        }

        public Telefone Build() {
            return new Telefone(id, ddd, numero, tipoId, tipo);
        }

    }
}
