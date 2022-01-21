using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_API_1.Entidades;

namespace Cadastro_API_1.Infraestrutura.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Task<Usuario> GetByNome(string Nome);

        Task<List<Usuario>> SearchByNome(string Nome);

        Task<List<Usuario>> SearchByCPF(string CPF);

        Task<Usuario> GetByCPF(string CPF);

        Task<Usuario> BuscarUsuarioTelefones(long id);
    }
}
