using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioStefanini.Application.Commands;
using DesafioStefanini.Application.DTOs;
using DesafioStefanini.Domain.Interfaces;
using MediatR;

namespace DesafioStefanini.Application.Handler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        
        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var personDb = _personRepository.GetByIdAsync(request.Id).Result;
            if (personDb == null)
            {
                return false;
            }

            _personRepository.Delete(personDb);
            return true;
        }
    }
}
