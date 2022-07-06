using DesafioStefanini.Application.DTOs;
using DesafioStefanini.Application.Validators;
using MediatR;

namespace DesafioStefanini.Application.Commands
{
    public class CreatePersonCommand : IRequest<PersonDTO>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string CityName { get; set; }
        public string CityUF { get; set; }
    }
}
