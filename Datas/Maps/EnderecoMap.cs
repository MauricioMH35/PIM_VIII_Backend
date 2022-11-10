using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.Datas.Maps {
    public class EnderecoMap : IEntityTypeConfiguration<Endereco> {

        public void Configure(EntityTypeBuilder<Endereco> builder) {
            builder.HasKey(x => x.id);
            builder.Property(x => x.logradouro)
                .HasMaxLength(256);
            builder.Property(x => x.numero)
                .IsRequired(true);
            builder.Property(x => x.cep)
                .IsRequired(true);
            builder.Property(x => x.bairro)
                .HasMaxLength(100);
            builder.Property(x => x.cidade)
                .HasMaxLength(100);
            builder.Property(x => x.estado)
                .HasMaxLength(2);
        }

    }
}
