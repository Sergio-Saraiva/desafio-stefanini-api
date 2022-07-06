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
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, ICityRepository cityRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            var result = _mapper.Map<PersonDTO>(await _personRepository.CreateAsync(person)); 
            return result;
        }
    }
}
