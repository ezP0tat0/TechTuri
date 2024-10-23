using AutoMapper;
using TechTuri.Model;
using TechTuri.Model.Data;
using TechTuri.Model.Dtos;

namespace TechTuri.Mappers
{
    public class ProfileMapperConfig:AutoMapper.Profile
    {
        public ProfileMapperConfig() 
        {
            CreateMap<RegisterDto, TechTuri.Model.Data.Profile>()
                .ForMember(dest=>dest.joinDate,opt=>opt.MapFrom(src=>(DateTime)src.joinDate));
        }
    }
}
