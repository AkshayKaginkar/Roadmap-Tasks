using AutoMapper;
using Session5.Context;
using Session5.Models;

namespace Session5.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<RegisterUserDTO, AppUser>().ReverseMap();
        }
    }
}
