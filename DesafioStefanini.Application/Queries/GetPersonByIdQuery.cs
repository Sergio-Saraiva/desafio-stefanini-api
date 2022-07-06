using System;
using DesafioStefanini.Application.DTOs;
using MediatR;

namespace DesafioStefanini.Application.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonDTO>
    {
        public string Id { get; set; }
        public GetPersonByIdQuery(string id)
        {
            Id = id;    
        }
    }
}
