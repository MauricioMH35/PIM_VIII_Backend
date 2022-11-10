using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas.Maps;
using PIM_VIII.Models;

namespace PIM_VIII.Datas {
    public class BancoDadosContext : DbContext {

        public BancoDadosContext(DbContextOptions options) : base(options) {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
            modelBuilder.ApplyConfiguration(new TipoTelefoneMap());
            modelBuilder.ApplyConfiguration(new PessoaTelefoneMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
