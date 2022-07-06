using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioStefanini.Application.DTOs;
using DesafioStefanini.Application.Queries;
using DesafioStefanini.Domain.Interfaces;
using MediatR;

namespace DesafioStefanini.Application.Handler
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IQueryable<PersonDTO>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public GetPersonsQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<PersonDTO>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {

            var persons = _mapper.Map<List<PersonDTO>>(_personRepository.GetAllAsync().Result.ToList());

            return persons.AsQueryable();
        }
    }
}
