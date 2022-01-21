using Cadastro_API_1.GerenServicos.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro_API_1.GerenServicos.Interfaces
{
    public interface ITelefoneServico
    {
        Task<TelefoneDTO> Create(TelefoneDTO telefoneDTO);

        Task<TelefoneDTO> Update(long id, TelefoneDTO telefoneDTO);

        Task Remove(long id);

        Task<TelefoneDTO> Get(long id);

        Task<List<TelefoneDTO>> Get();

        Task<List<TelefoneDTO>> SearchByNumero(string numero);

        Task<TelefoneDTO> GetById(long id);
    }
}
