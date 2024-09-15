using AutoMapper;
using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.DAL.Models;

namespace marketplaceAPI.BLL.Mapper
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginWithCredsDto>().ReverseMap();
            CreateMap<User, UserRegisterWithCredsDto>().ReverseMap();
        }
    }
}
