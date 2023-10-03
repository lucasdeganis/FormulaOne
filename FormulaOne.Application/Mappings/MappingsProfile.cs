using AutoMapper;
using FormulaOne.Domain.DTO;
using FormulaOne.Domain.Entities;

namespace FormulaOne.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Driver, DriverDto>().ReverseMap();
        }
    }
}
