using Microsoft.EntityFrameworkCore;
using Cadastro_API_1.Infraestrutura.Mapeamento;
using Cadastro_API_1.Entidades;
using System.Reflection;

namespace Cadastro_API_1.Infraestrutura.Contexto
{
    public class GerenciadorContexto : DbContext
    {
        public GerenciadorContexto() { }

        public GerenciadorContexto(DbContextOptions<GerenciadorContexto> options) : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
