namespace PIM_VIII.Models.Builders {
    public class TipoTelefoneBuilder {

        private int id;
        private string tipo;

        public TipoTelefoneBuilder Id(int id) { 
            this.id = id; 
            return this; 
        }

        public TipoTelefoneBuilder Tipo(string tipo) {
            this.tipo = tipo; 
            return this; 
        }

        public TipoTelefone Build() { 
            return new TipoTelefone(id, tipo);
        }

    }
}
