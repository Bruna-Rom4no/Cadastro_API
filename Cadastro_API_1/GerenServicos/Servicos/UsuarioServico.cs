using AutoMapper;
using Cadastro.API.ViewModel;
using Cadastro_API_1.Entidades;
using Cadastro_API_1.GerenCore.Exceçoes;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.GerenServicos.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IMapper _mapper;

        private readonly IRepositorioUsuario _usuarioRepositorio;

        public UsuarioServico(IMapper mapper, IRepositorioUsuario usuarioRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {
            var userExist = await _usuarioRepositorio.GetByNome(usuarioDTO.Nome);

            if (userExist != null)
                throw new ExcecaoDominio("Já existe um usuário cadastrado com esse nome.");

            var user = _mapper.Map<Usuario>(usuarioDTO);
            user.Validar();

            var userCreated = await _usuarioRepositorio.Create(user);

            return _mapper.Map<UsuarioDTO>(userCreated);
        }

        public async Task<UsuarioDTO> Update(long id, UsuarioDTO usuarioDTO)
        {
            var userExiste = await _usuarioRepositorio.Get(id);

            if (userExiste == null)
                throw new ExcecaoDominio("Não existe nenhum usuário com o id informado!");


            userExiste.MudarNome(usuarioDTO.Nome);
            userExiste.MudarCpf(usuarioDTO.CPF);
            userExiste.Validar();

            var userUpdate = await _usuarioRepositorio.Update(userExiste);

            return _mapper.Map<UsuarioDTO>(userUpdate);
        }

        public async Task Remove(long id)
        {
            var usuario = await _usuarioRepositorio.Get(id);

            if (usuario == null)
                throw new ExcecaoDominio("Não existe nenhum usuário com o id informado!");

            usuario.MudarAtivo(false);

            await _usuarioRepositorio.Update(usuario);
        }

        public async Task<UsuarioDTO> Get(long id)
        {
            var user = await _usuarioRepositorio.Get(id);

            return _mapper.Map<UsuarioDTO>(user);
        }

        public async Task<List<UsuarioDTO>> Get()
        {
            var allUser = await _usuarioRepositorio.Get();

            return _mapper.Map<List<UsuarioDTO>>(allUser);
        }

        public async Task<List<UsuarioDTO>> Get_()
        {
            var allUser2 = await _usuarioRepositorio.Get();

            return _mapper.Map<List<UsuarioDTO>>(allUser2);
        }

        public async Task<List<UsuarioDTO>> SearchByNome(string nome)
        {
            var allUser = await _usuarioRepositorio.SearchByNome(nome);

            return _mapper.Map<List<UsuarioDTO>>(allUser);
        }

        public async Task<UsuarioDTO> GetByNome(string nome)
        {
            var user = await _usuarioRepositorio.GetByNome(nome);

            return _mapper.Map<UsuarioDTO>(user);
        }

        public async Task<List<UsuarioDTO>> SearchByCPF(string cpf)
        {
            var allUser = await _usuarioRepositorio.SearchByCPF(cpf);

            return _mapper.Map<List<UsuarioDTO>>(allUser);
        }

        public async Task<UsuarioDTO> GetByCPF(string cpf)
        {
            var user = await _usuarioRepositorio.GetByCPF(cpf);

            return _mapper.Map<UsuarioDTO>(user);
        }

        public async Task<UsuarioTelefonesViewModel> BuscarTelefonesUsuario(long id)
        {
            var usuarioTelefones = _mapper.Map<UsuarioTelefonesViewModel>(await _usuarioRepositorio.BuscarUsuarioTelefones(id));

            return usuarioTelefones;
        }
    }
}
