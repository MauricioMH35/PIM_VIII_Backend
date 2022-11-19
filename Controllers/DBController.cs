using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII.Controllers {

    [ApiController]
    [Route("/v1/api/[controller]")]
    public class DBController : ControllerBase {

        private readonly IPessoaRepository pessoaRepository;
        private readonly IEnderecoRepository enderecoRepository;
        private readonly ITelefoneRepository telefoneRepository;
        private readonly ITipoTelefoneRepository tipoTelefoneRepository;
        private readonly IPessoaTelefoneRepository pessoaTelefoneRepository;

        private List<Pessoa> pessoas = new List<Pessoa>();
        private List<Endereco> enderecos = new List<Endereco>();
        private List<Telefone> telefones = new List<Telefone>();
        private List<TipoTelefone> tiposTelefone = new List<TipoTelefone>();
        private List<PessoaTelefone> pessoaTelefones = new List<PessoaTelefone>();

        public DBController(IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository,
            ITelefoneRepository telefoneRepository, ITipoTelefoneRepository tipoTelefoneRepository,
            IPessoaTelefoneRepository pessoaTelefoneRepository) {
            this.pessoaRepository = pessoaRepository;
            this.enderecoRepository = enderecoRepository;
            this.telefoneRepository = telefoneRepository;
            this.tipoTelefoneRepository = tipoTelefoneRepository;
            this.pessoaTelefoneRepository = pessoaTelefoneRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Init() {
            StartTipoTelefone();
            StartTelefone();
            StartEndereco();
            StartPessoa();
            StartPessoaTelefone();
            string resposta = "";

            resposta += InitTipoTelefone();
            resposta += InitTelefone();
            resposta += InitEndereco();
            resposta += InitPessoas();
            resposta += InitPessoaTelefone();

            return Ok(resposta);
        }

        private string InitTipoTelefone() {
            string resposta = "";

            foreach (TipoTelefone tipoTelefone in tiposTelefone) {
                if (tipoTelefoneRepository.Adicionar(tipoTelefone).Result) {
                    resposta += $"{tipoTelefone.tipo} adicionado(a) com sucesso!\n";
                }
            }
            return resposta;
        }

        private string InitTelefone() {
            string resposta = "";

            foreach (Telefone telefone in telefones) {
                if (telefoneRepository.Adicionar(telefone).Result) {
                    resposta += $"({telefone.ddd}) {telefone.numero} adicionado(a) com sucesso!\n";
                }
            }
            return resposta;
        }

        private string InitEndereco() {
            string resposta = "";

            foreach (Endereco endereco in enderecos) {
                if (enderecoRepository.Adicionar(endereco).Result) {
                    resposta += $"{endereco.logradouro}, {endereco.numero}, {endereco.cep}... " +
                        $"adicionado(a) com sucesso!\n";
                }
            }
            return resposta;
        }

        private string InitPessoas() {
            string resposta = "";

            foreach (Pessoa pessoa in pessoas) {
                if (pessoaRepository.Adicionar(pessoa).Result) {
                    resposta += $"{pessoa.nome} adicionado(a) com sucesso!\n";
                }
            }
            return resposta;
        }

        private string InitPessoaTelefone() {
            string resposta = "";

            foreach (PessoaTelefone pessoaTelefone in pessoaTelefones) {
                if (pessoaTelefoneRepository.Adicionar(pessoaTelefone).Result) {
                    resposta += $"pessoaTelefone com id[{pessoaTelefone.id}] adicionado(a) com sucesso!\n";
                }
            }
            return resposta;
        }

        private void StartTipoTelefone() {
            tiposTelefone.Add(TipoTelefone.Builder()
                .Id(0)
                .Tipo("Pessoal")
                .Build());
            tiposTelefone.Add(TipoTelefone.Builder()
                .Id(0)
                .Tipo("Residencia")
                .Build());
            tiposTelefone.Add(TipoTelefone.Builder()
                .Id(0)
                .Tipo("Recado")
                .Build());
            tiposTelefone.Add(TipoTelefone.Builder()
                .Id(0)
                .Tipo("Trabalho")
                .Build());
        }

        private void StartTelefone() {
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(11)
                .Numero(982444604)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(54)
                .Numero(983467870)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(85)
                .Numero(38590425)
                .TipoId(2) // Residencial
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(24)
                .Numero(26176277)
                .TipoId(4) // Trabalho
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(48)
                .Numero(991587542)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(61)
                .Numero(994674084)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(51)
                .Numero(35113600)
                .TipoId(3) // Recado
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(12)
                .Numero(98503 - 0255)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(97)
                .Numero(998651546)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(61)
                .Numero(99385 - 1843)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(21)
                .Numero(987653931)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(69)
                .Numero(995962165)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(84)
                .Numero(38270660)
                .TipoId(2) // Residencia
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(11)
                .Numero(999550006)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(63)
                .Numero(38538673)
                .TipoId(4) // Trabalho
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(79)
                .Numero(982040756)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(89)
                .Numero(982771941)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(11)
                .Numero(982231830)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(11)
                .Numero(99844 - 9445)
                .TipoId(1) // Pessoal
                .Build());
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd(41)
                .Numero(98810 - 8611)
                .TipoId(1) // Pessoal
                .Build());

            /*
            telefones.Add(Telefone.Builder()
                .Id(0)
                .Ddd()
                .Numero()
                .TipoId(1) // Pessoal
                .Build());
            */
        }

        private void StartEndereco() {
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Travessa Antônio Vieira")
                .Numero(366)
                .Cep("58704-473")
                .Bairro("Bela Vista")
                .Cidade("Patos")
                .Estado("PB")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Stella Giacomina Barpe Sarvador")
                .Numero(243)
                .Cep("95074-605")
                .Bairro("São Luiz")
                .Cidade("Caxias do Sul")
                .Estado("RS")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Matias Beck")
                .Numero(585)
                .Cep("60356-110")
                .Bairro("Presidente Kennedy")
                .Cidade("Fortaleza")
                .Estado("CE")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Servidão Braz Augusto Carvalho")
                .Numero(763)
                .Cep("25715-409")
                .Bairro("Vale do Carangola")
                .Cidade("Petrópolis")
                .Estado("RJ")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Rubens Faraco")
                .Numero(594)
                .Cep("88704-440")
                .Bairro("Humaitá")
                .Cidade("Tubarão")
                .Estado("SC")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Quadra QR 118 Conjunto P")
                .Numero(469)
                .Cep("72548-416")
                .Bairro("Santa Maria")
                .Cidade("Brasília")
                .Estado("DF")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Ovídio Trigo Loureiro")
                .Numero(938)
                .Cep("96505-090")
                .Bairro("Quinta da Boa Vista")
                .Cidade("Cachoeira do Sul")
                .Estado("RS")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Itapetininga")
                .Numero(439)
                .Cep("12240-571")
                .Bairro("Jardim Alvorada")
                .Cidade("São José dos Campos")
                .Estado("SP")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Vitória Régia")
                .Numero(986)
                .Cep("69510-970")
                .Bairro("Centro")
                .Cidade("Itamarati")
                .Estado("AM")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Quadra SQSW")
                .Numero(719)
                .Cep("70673-304")
                .Bairro("Setor Sudoeste")
                .Cidade("Brasília")
                .Estado("DF")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Amaragi II")
                .Numero(771)
                .Cep("26116-751")
                .Bairro("Santa Amélia")
                .Cidade("Belford Roxo")
                .Estado("RJ")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Água Marinha")
                .Numero(125)
                .Cep("76828-480")
                .Bairro("Jardim Santana")
                .Cidade("Porto Velho")
                .Estado("RO")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Travessa Campo Santo")
                .Numero(180)
                .Cep("59104-058")
                .Bairro("Igapó")
                .Cidade("Natal")
                .Estado("RN")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Avenida Augusta")
                .Numero(360)
                .Cep("69305-268")
                .Bairro("São Francisco")
                .Cidade("Boa Vista")
                .Estado("SP")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Carminha")
                .Numero(267)
                .Cep("77433-14")
                .Bairro("Trevo Oeste")
                .Cidade("Gurupi")
                .Estado("TO")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Canal II")
                .Numero(462)
                .Cep("49092-678")
                .Bairro("Olaria")
                .Cidade("Aracaju")
                .Estado("SE")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua do Arame")
                .Numero(112)
                .Cep("65055-030")
                .Bairro("Jardim São Cristóvão")
                .Cidade("São Luís")
                .Estado("MA")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Vila São José")
                .Numero(757)
                .Cep("09075-381")
                .Bairro("Nova Descoberta")
                .Cidade("Natal")
                .Estado("SP")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Evaristo da Veiga")
                .Numero(528)
                .Cep("05035-190")
                .Bairro("Liberdade")
                .Cidade("São Paulo")
                .Estado("SP")
                .Build());
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("Rua Dionízio Dal'Negro")
                .Numero(712)
                .Cep("83025-335")
                .Bairro("Santo Antônio")
                .Cidade("São José dos Pinhais")
                .Estado("PR")
                .Build());

            /*
            enderecos.Add(Endereco.Builder()
                .Id(0)
                .Logradouro("")
                .Numero()
                .Cep("")
                .Bairro("")
                .Cidade("")
                .Estado("")
                .Build());
            */
        }

        private void StartPessoa() {
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Levi Luan Henry Santos")
                .Cpf(73497070106)
                .EnderecoId(1)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Yasmin Emilly Heloise Rocha")
                .Cpf(31977684424)
                .EnderecoId(2)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Luiz Davi Fábio Sales")
                .Cpf(17144346997)
                .EnderecoId(3)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Danilo Noah da Cunha")
                .Cpf(87095656126)
                .EnderecoId(4)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Márcio César Breno Fernandes")
                .Cpf(67248260398)
                .EnderecoId(5)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Natália Caroline Josefa Barros")
                .Cpf(49536598213)
                .EnderecoId(6)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Pedro Miguel Figueiredo")
                .Cpf(88790464036)
                .EnderecoId(7)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Elias Igor Aparício")
                .Cpf(97609896039)
                .EnderecoId(8)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Francisco Felipe Almada")
                .Cpf(92644041635)
                .EnderecoId(9)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Maya Andrea Freitas")
                .Cpf(36052430109)
                .EnderecoId(10)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Benício Oliver Gonçalves")
                .Cpf(82750039622)
                .EnderecoId(11)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Teresinha Joana da Cruz")
                .Cpf(29575060415)
                .EnderecoId(12)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Aurora Benedita da Paz")
                .Cpf(71053975945)
                .EnderecoId(13)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Anderson Oliver Nascimento")
                .Cpf(52443917800)
                .EnderecoId(14)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Nathan Severino Bernardes")
                .Cpf(48283785370)
                .EnderecoId(15)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Vitor Matheus Moreira")
                .Cpf(16699461699)
                .EnderecoId(16)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Diego Bryan Lucca Ferreira")
                .Cpf(15230211520)
                .EnderecoId(17)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Isabela Gabrielly Brito")
                .Cpf(02796185141)
                .EnderecoId(18)
                .Build());
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("Bruna Lara Araújo")
                .Cpf(29167733980)
                .EnderecoId(19)
                .Build());
            pessoas.Add(Pessoa.Builder()
               .Id(0)
               .Nome("Manuel Julio Aragão")
               .Cpf(51930870353)
               .EnderecoId(20)
               .Build());

            /*
            pessoas.Add(Pessoa.Builder()
                .Id(0)
                .Nome("")
                .Cpf()
                .EnderecoId()
                .Build());
            */
        }

        private void StartPessoaTelefone() {
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(1)
                .TelefoneId(1)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(2)
                .TelefoneId(2)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(3)
                .TelefoneId(3)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(4)
                .TelefoneId(4)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(5)
                .TelefoneId(5)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(6)
                .TelefoneId(6)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(7)
                .TelefoneId(7)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(8)
                .TelefoneId(8)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(9)
                .TelefoneId(9)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(10)
                .TelefoneId(10)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(11)
                .TelefoneId(11)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(12)
                .TelefoneId(12)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(13)
                .TelefoneId(13)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(14)
                .TelefoneId(14)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(15)
                .TelefoneId(15)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(16)
                .TelefoneId(16)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(17)
                .TelefoneId(17)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(18)
                .TelefoneId(18)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(19)
                .TelefoneId(19)
                .Build());
            pessoaTelefones.Add(PessoaTelefone.Builder()
                .Id(0)
                .PessoaId(20)
                .TelefoneId(20)
                .Build());
        }

    }
}
