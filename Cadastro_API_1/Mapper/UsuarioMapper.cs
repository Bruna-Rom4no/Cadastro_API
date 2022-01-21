using AutoMapper;
using Cadastro.API.ViewModel;
using Cadastro_API_1.Entidades;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.GerenServicos.Servicos;
using Cadastro_API_1.ViewModel;
using System.Linq;

namespace Cadastro.API.Mapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<IUsuarioServico, UsuarioServico>().ReverseMap();
            CreateMap<CreateUsuarioViewModel, UsuarioDTO>().ReverseMap();
            CreateMap<UpdateUsuarioViewModel, UsuarioDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioTelefonesViewModel>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, o => o.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cpf, o => o.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Telefones, o => o.MapFrom(src => src.Telefones.Select(x => new TelefonesViewModel(x.Id, x.Numero)).ToList()));
        }
    }
}
