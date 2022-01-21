using Cadastro_API_1.Entidades;
using Cadastro_API_1.Infraestrutura.Contexto;
using Cadastro_API_1.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.Infraestrutura.Repositorio
{
    public class RepositorioTelefone : RepositorioBase<Telefone>, IRepositorioTelefone
    {
        private readonly GerenciadorContexto _context;

        public RepositorioTelefone(GerenciadorContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<Telefone> GetById(long id)
        {
            var usuario = await _context.Telefones.Where(y => y.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<List<Telefone>> SearchByNumero(string Numero)
        {
            var Usuarios = await _context.Telefones.Where(y => y.Numero.ToLower().Contains(Numero.ToLower())).AsNoTracking().ToListAsync();

            return Usuarios;
        }
    }
}
