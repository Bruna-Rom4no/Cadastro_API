using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_API_1.Entidades;

namespace Cadastro_API_1.Infraestrutura.Interfaces
{
    public interface IRepositorioBase<T> where T : Base
    {
        Task<T> Create(T obj);
        
        Task<T> Update(T obj);
        
        Task<T> Remove(long Id);
        
        Task<T> Get(long Id);
        
        Task<List<T>> Get();
    }
}
