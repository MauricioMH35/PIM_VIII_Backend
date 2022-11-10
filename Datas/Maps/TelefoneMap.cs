using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.Datas.Maps {
    public class TelefoneMap : IEntityTypeConfiguration<Telefone> {

        public void Configure(EntityTypeBuilder<Telefone> builder) {
            builder.HasKey(x => x.id);
            builder.Property(x => x.ddd)
                .IsRequired(true);
            builder.Property(x => x.numero)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(9);
            builder.HasOne(x => x.tipo);
        }

    }
}
