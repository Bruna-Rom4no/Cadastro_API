using Cadastro_API_1.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_API_1.Infraestrutura.Mapeamento
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().HasColumnType("BIGINT");

            builder.Property(x => x.Nome).HasMaxLength(250).HasColumnType("VARCHAR").IsRequired();

            builder.Property(x => x.CPF).HasColumnType("VARCHAR(11)").IsRequired();

            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
