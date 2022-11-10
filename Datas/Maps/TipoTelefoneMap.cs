using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.Datas.Maps {
    public class TipoTelefoneMap : IEntityTypeConfiguration<TipoTelefone> {

        public void Configure(EntityTypeBuilder<TipoTelefone> builder) {
            builder.HasKey(x => x.id);
            builder.Property(x => x.tipo)
                .IsRequired(true)
                .HasMaxLength(10);
        }

    }
}
