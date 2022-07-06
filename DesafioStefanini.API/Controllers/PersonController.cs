using System;
using System.Threading.Tasks;
using DesafioStefanini.Application.Commands;
using DesafioStefanini.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            var result = await _mediator.Send(createPersonCommand).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var getPersonsQuery = new GetPersonsQuery();
            var result = await _mediator.Send(getPersonsQuery).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetPersonById(string personId)
        {
            var getPersonByIdQuery = new GetPersonByIdQuery(personId);
            var result = await _mediator.Send(getPersonByIdQuery).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand updatePersonCommand)
        {
            var result = await _mediator.Send(updatePersonCommand).ConfigureAwait(false);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePerson(string personId)
        {
            var deletePersonCommand = new DeletePersonCommand(personId);
            var result = await _mediator.Send(deletePersonCommand).ConfigureAwait(false);

            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
