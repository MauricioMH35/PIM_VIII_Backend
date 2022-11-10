using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.Datas.Maps {
    public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefone> {

        public void Configure(EntityTypeBuilder<PessoaTelefone> builder) {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.pessoa).WithOne();
            builder.HasMany(x => x.telefones);
        }

    }
}
