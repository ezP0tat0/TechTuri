using AutoMapper;
using TechTuri.Model;
using TechTuri.Model.Data;
using TechTuri.Model.Dtos;

namespace TechTuri.Mappers
{
    public class ProfileMapperConfig:Profile
    {
        public ProfileMapperConfig() 
        {
            CreateMap<RegisterDto, User>();
        }
    }
    public class MapppigProfile : Profile
    {
        public MapppigProfile()
        {
            CreateMap<ItemDto, Item>();
        }
    }
}
