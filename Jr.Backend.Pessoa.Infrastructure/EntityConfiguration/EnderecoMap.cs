using Jr.Backend.Pessoa.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jr.Backend.Pessoa.Infrastructure.EntityConfiguration
{
    public class EnderecoMap
    : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Pessoa)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.PessoaId);
        }
    }
}