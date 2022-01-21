using Cadastro.API.ViewModel;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.GerenServicos.Interfaces
{
    public interface IUsuarioServico
    {
        Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO);
        
        Task<UsuarioDTO> Update(long id, UsuarioDTO usuarioDTO);
        
        Task Remove(long id);
        
        Task<UsuarioDTO> Get(long id);
        
        Task<List<UsuarioDTO>> Get();
        
        Task<List<UsuarioDTO>> SearchByNome(string nome);
        
        Task<List<UsuarioDTO>> SearchByCPF(string nome);
        
        Task<UsuarioDTO> GetByNome(string nome);
        
        Task<UsuarioDTO> GetByCPF(string nome);
        Task<UsuarioTelefonesViewModel> BuscarTelefonesUsuario(long id);
    }
}
