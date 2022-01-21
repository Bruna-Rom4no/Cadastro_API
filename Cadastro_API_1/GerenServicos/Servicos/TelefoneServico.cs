using AutoMapper;
using Cadastro_API_1.Entidades;
using Cadastro_API_1.GerenCore.Exceçoes;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.Infraestrutura.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro_API_1.GerenServicos.Servicos
{
    public class TelefoneServico : ITelefoneServico
    {
        private readonly IMapper _mapper;

        private readonly IRepositorioTelefone _telefoneRepositorio;

        public TelefoneServico(IMapper mapper, IRepositorioTelefone repositorioTelefone)
        {
            _mapper = mapper;
            _telefoneRepositorio = repositorioTelefone;
        }
        public async Task<TelefoneDTO> Create(TelefoneDTO telefoneDTO)
        {
            var telefoneExists = await _telefoneRepositorio.SearchByNumero(telefoneDTO.Numero);

            if (telefoneExists.Count > 0)
                throw new ExcecaoDominio("Já existe um telefone cadastrado com esse numero.");

            var user = _mapper.Map<Telefone>(telefoneDTO);
            user.Validar();

            var userCreated = await _telefoneRepositorio.Create(user);

            return _mapper.Map<TelefoneDTO>(userCreated);
        }

        public async Task<TelefoneDTO> Update(long id, TelefoneDTO telefoneDTO)
        {
            var telefoneExiste = await _telefoneRepositorio.Get(id);

            if (telefoneExiste == null)
                throw new ExcecaoDominio("Não existe nenhum usuário com o id onformado!");

            telefoneExiste.MudarNumero(telefoneDTO.Numero);
            telefoneExiste.Validar();

            var telefoneUpdate = await _telefoneRepositorio.Update(telefoneExiste);

            return _mapper.Map<TelefoneDTO>(telefoneUpdate);
        }

        public async Task Remove(long id)
        {
            var telefoneExiste = await _telefoneRepositorio.Get(id);

            if (telefoneExiste == null)
                throw new ExcecaoDominio("Não existe telefone para o identificador inserido!");

            telefoneExiste.MudarAtivo(false);

            await _telefoneRepositorio.Update(telefoneExiste);
        }

        public async Task<TelefoneDTO> Get(long id)
        {
            var user = await _telefoneRepositorio.Get(id);

            return _mapper.Map<TelefoneDTO>(user);
        }

        public async Task<List<TelefoneDTO>> Get()
        {
            var allUser = await _telefoneRepositorio.Get();

            return _mapper.Map<List<TelefoneDTO>>(allUser);
        }

        public async Task<List<TelefoneDTO>> Get_()
        {
            var allUser2 = await _telefoneRepositorio.Get();

            return _mapper.Map<List<TelefoneDTO>>(allUser2);
        }

        public async Task<List<TelefoneDTO>> SearchByNumero(string numero)
        {
            var allUser = await _telefoneRepositorio.SearchByNumero(numero);

            return _mapper.Map<List<TelefoneDTO>>(allUser);
        }

        public async Task<TelefoneDTO> GetById(long id)
        {
            var user = await _telefoneRepositorio.GetById(id);

            return _mapper.Map<TelefoneDTO>(user);
        }
    }
}
