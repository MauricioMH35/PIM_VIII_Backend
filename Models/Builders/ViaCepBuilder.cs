namespace PIM_VIII.Models.Builders {
    public class ViaCepBuilder {

        private string cep;
        private string logradouro;
        private string complemento;
        private string bairro;
        private string localidade;
        private string uf;
        private string ibge;
        private string gia;
        private string ddd;
        private string siafi;

        public ViaCepBuilder Cep(string cep) { 
            this.cep = cep; 
            return this; 
        }

        public ViaCepBuilder Logradouro(string logradouro) {
            this.logradouro = logradouro; 
            return this; 
        }

        public ViaCepBuilder Complemento(string complemento) {
            this.complemento = complemento; 
            return this; 
        }

        public ViaCepBuilder Bairro(string bairro) {
            this.bairro = bairro; 
            return this; 
        }

        public ViaCepBuilder Localidade(string localidade) {
            this.localidade = localidade; 
            return this; 
        }

        public ViaCepBuilder Uf(string uf) {
            this.uf = uf; 
            return this; 
        }

        public ViaCepBuilder Ibge(string ibge) {
            this.ibge = ibge; 
            return this; 
        }

        public ViaCepBuilder Gia(string gia) {
            this.gia = gia; 
            return this; 
        }

        public ViaCepBuilder Ddd(string ddd) {
            this.ddd = ddd; 
            return this; 
        }

        public ViaCepBuilder Siafi(string siafi) {
            this.siafi = siafi; 
            return this; 
        }

        public ViaCep Build() {
            return new ViaCep(
                cep, 
                logradouro, 
                complemento, 
                bairro, 
                localidade, 
                uf, 
                ibge, 
                gia, 
                ddd, 
                siafi
            );
        }

    }
}
