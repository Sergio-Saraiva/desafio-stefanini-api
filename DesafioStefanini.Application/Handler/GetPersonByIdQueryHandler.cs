using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioStefanini.Application.DTOs;
using DesafioStefanini.Application.Queries;
using DesafioStefanini.Domain.Interfaces;
using MediatR;

namespace DesafioStefanini.Application.Handler
{
    internal class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;   
            _mapper = mapper;
        }

        public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PersonDTO>(await _personRepository.GetByIdAsync(request.Id.ToString()));
        }
    }
}
