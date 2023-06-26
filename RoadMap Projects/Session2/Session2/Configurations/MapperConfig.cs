using AutoMapper;
using Session2.Models;

namespace Session2.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        { 
            CreateMap<Pizza,PizzaListVM>().ReverseMap();
        }
    }
}
