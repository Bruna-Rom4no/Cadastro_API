using Cadastro.API.Mapper;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.GerenServicos.Servicos;
using Cadastro_API_1.Infraestrutura.Interfaces;
using Cadastro_API_1.Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Cadastro.API.DependencyInjection
{
    public static class ExtensionDependencyInjection
    {
        public static void RegistrerDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<ITelefoneServico, TelefoneServico>();
            services.AddScoped<IRepositorioTelefone, RepositorioTelefone>();

            services.AddAutoMapper(typeof(UsuarioMapper));
            services.AddAutoMapper(typeof(TelefoneMapper));
        }
    }
}
