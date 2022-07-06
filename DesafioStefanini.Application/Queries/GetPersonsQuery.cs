using System.Collections.Generic;
using System.Linq;
using DesafioStefanini.Application.DTOs;
using MediatR;

namespace DesafioStefanini.Application.Queries
{
    public class GetPersonsQuery : IRequest<IQueryable<PersonDTO>>
    {
    }
}
