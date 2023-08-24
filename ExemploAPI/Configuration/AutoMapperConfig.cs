using AutoMapper;
using ExemploAPI.Models;
using ExemploAPI.ViewModel;

namespace ExemploAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
