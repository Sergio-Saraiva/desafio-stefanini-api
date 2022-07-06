using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioStefanini.Application.Commands;
using DesafioStefanini.Application.DTOs;
using DesafioStefanini.Domain.Enitities;
using DesafioStefanini.Domain.Interfaces;
using MediatR;

namespace DesafioStefanini.Application.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public UpdatePersonCommandHandler(IPersonRepository personRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            var personExists = _personRepository.GetByIdAsync(person.Id).Result;
            if(personExists == null)
            {
                return null;
            }
            person.City.Id = personExists.City.Id;
            person.City.CreatedAt = personExists.City.CreatedAt;
            person.City.UpdatedAt = DateTime.Now;
            person.CreatedAt = personExists.CreatedAt;
            person.UpdatedAt = DateTime.Now;
            
            return _mapper.Map<PersonDTO>(await _personRepository.Update(person));
        }
    }
}
