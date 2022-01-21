using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_API_1.Entidades;
using Cadastro_API_1.Infraestrutura.Contexto;
using Cadastro_API_1.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_API_1.Infraestrutura.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Base
    {
        private readonly GerenciadorContexto _context;

        public RepositorioBase(GerenciadorContexto context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Remove(long Id)
        {
            var obj = await Get(Id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }

            return obj;
        }

        public virtual async Task<T> Get(long Id)
        {
            var obj = await _context.Set<T>().AsNoTracking().Where(x => x.Id == Id).ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
