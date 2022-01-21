using AutoMapper;
using Cadastro_API_1.Entidades;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.ViewModel;

namespace Cadastro.API.Mapper
{
    public class TelefoneMapper : Profile
    {
        public TelefoneMapper()
        {
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<CreateTelefoneViewModel, TelefoneDTO>().ReverseMap();
            CreateMap<UpdateTelefoneViewModel, TelefoneDTO>().ReverseMap();
        }
    }
}
