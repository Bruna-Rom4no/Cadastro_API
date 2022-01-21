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
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        private readonly GerenciadorContexto _context;

        public RepositorioUsuario(GerenciadorContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByNome(string Nome)
        {
            var usuario = await _context.Usuarios.Where(x => x.Nome.ToLower() == Nome.ToLower()).AsNoTracking().ToListAsync();

            return usuario.FirstOrDefault();
        }

        public async Task<List<Usuario>> SearchByNome(string Nome)
        {
            var todosUsuarios = await _context.Usuarios.Where(x => x.Nome.ToLower().Contains(Nome.ToLower())).AsNoTracking().ToListAsync();

            return todosUsuarios;
        }

        public async Task<List<Usuario>> SearchByCPF(string CPF)
        {
            var TodosUsuarios = await _context.Usuarios.Where(x => x.CPF.ToLower().Contains(CPF.ToLower())).AsNoTracking().ToListAsync();

            return TodosUsuarios;
        }

        public async Task<Usuario> GetByCPF(string CPF)
        {
            var usuario = await _context.Usuarios.Where(x => x.CPF.ToLower() == CPF.ToLower()).AsNoTracking().ToListAsync();

            return usuario.FirstOrDefault();
        }

        public async Task<Usuario> BuscarUsuarioTelefones(long id)
        {
            var usuarioTelefones = await _context.Usuarios.AsNoTracking().Where(x => x.Id == id).Include(x => x.Telefones).FirstOrDefaultAsync();

            return usuarioTelefones;
        }
    }
}
