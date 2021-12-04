using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jr.Backend.Pessoa.Infrastructure.EntityConfiguration
{
    public class PessoaMap : IEntityTypeConfiguration<Entity.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Entity.Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}