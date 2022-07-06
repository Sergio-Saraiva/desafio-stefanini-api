using DesafioStefanini.Application.DTOs;
using MediatR;

namespace DesafioStefanini.Application.Commands
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeletePersonCommand(string id)
        {
            Id = id;
        }
    }
}
