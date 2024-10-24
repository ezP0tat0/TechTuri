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
         //       .ForMember(dest=>dest.joinDate,opt=>opt.MapFrom(src=>(DateTime)src.joinDate));
        }
    }
}
