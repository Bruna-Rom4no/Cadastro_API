using Cadastro_API_1.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_API_1.Infraestrutura.Mapeamento
{
    public class MapTelefone : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");

            builder.HasKey(y => y.Id);

            builder.Property(y => y.Id).UseIdentityColumn().HasColumnType("BIGINT");

            builder.Property(y => y.Numero).HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Ativo).IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.Telefones)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
