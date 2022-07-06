using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioStefanini.Application.DTOs;
using MediatR;

namespace DesafioStefanini.Application.Commands
{
    public class UpdatePersonCommand : IRequest<PersonDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string CityName { get; set; }
        public string CityUF { get; set; }
    }
}
