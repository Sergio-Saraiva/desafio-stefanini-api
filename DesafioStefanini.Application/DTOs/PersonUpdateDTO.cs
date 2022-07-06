using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Application.DTOs
{
    public class PersonUpdateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Age { get; set; }
    }
}
