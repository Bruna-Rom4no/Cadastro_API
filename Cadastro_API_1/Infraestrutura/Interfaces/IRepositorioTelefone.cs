using Cadastro_API_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.Infraestrutura.Interfaces
{
    public interface IRepositorioTelefone : IRepositorioBase<Telefone>
    {
        Task<List<Telefone>> SearchByNumero(string Numero);

        Task<Telefone> GetById(long id); 
    }
}
