using DesafioStefanini.Application.DTOs;
using AutoMapper;
using DesafioStefanini.Domain.Enitities;
using DesafioStefanini.Application.Commands;

namespace DesafioStefanini.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonUpdateDTO>().ReverseMap();

            CreateMap<PersonDTO, CreatePersonCommand>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<PersonUpdateDTO, UpdatePersonCommand>().ReverseMap();
            CreateMap<Person, UpdatePersonCommand>().ReverseMap();
            CreateMap<PersonDTO, DeletePersonCommand>().ReverseMap();
        }
    }
}
