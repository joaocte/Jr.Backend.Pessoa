using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jr.Backend.Pessoa.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class PessoaController : ControllerBase
    {
        // GET api/<PessoaController>/5
        [HttpGet]
        public async Task<IEnumerable<Domain.Pessoa>> Get([FromServices] IMediator mediator, [FromQuery] ObterPessoaPorIdRequest request)
        {
            return await mediator.Send(request);
        }

        // POST api/<PessoaController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CadastrarPessoaRespose>> Post([FromServices] IMediator mediator,
            [FromBody] CadastrarPessoaRequest command)
        {
            CadastrarPessoaRespose commandResult = await mediator.Send(command);
            return CreatedAtAction("Get", new { id = commandResult?.Id }, commandResult);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<AtualizarPessoaResponse> Put(Guid id, [FromBody] PessoaResquest request, [FromServices] IMediator mediator)
        {
            AtualizarPessoaRequest command = new()
            { Enderecos = request.Enderecos, Id = id, };

            return await mediator.Send(command);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, [FromServices] IMediator mediator)
        {
            var command = new DeletarPessoaRequest(id);
            await mediator.Send(command);
            return NoContent();
        }
    }
}