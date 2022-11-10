using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.Datas.Maps {
    public class PessoaMap : IEntityTypeConfiguration<Pessoa> {

        public void Configure(EntityTypeBuilder<Pessoa> builder) {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).HasMaxLength(128);
            builder.Property(x => x.cpf).IsRequired().HasMaxLength(11);
            builder.HasIndex(x => x.cpf).IsUnique();
            builder.HasOne(x => x.endereco);
        }

    }
}
