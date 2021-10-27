using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jr.Backend.Pessoa.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PessoaController : ControllerBase
    {
        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public Task<ObterPessoaPorIdResponse> Get([FromServices] IMediator mediator, Guid id)
        {
            return mediator.Send(new ObterPessoaPorIdRequest(id));
        }

        // POST api/<PessoaController>
        [HttpPost]
        public Task<CadastrarPessoaRespose> Post([FromServices] IMediator mediator,
            [FromBody] CadastrarPessoaRequest command)
        {
            return mediator.Send(command);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public Task<AtualizarPessoaResponse> Put(Guid id, [FromBody] PessoaResquest request, [FromServices] IMediator mediator)
        {
            AtualizarPessoaRequest command = new()
            { Documentos = request.Documentos, Enderecos = request.Enderecos, Id = id, NomeCompleto = request.NomeCompleto };

            return mediator.Send(command);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id, [FromServices] IMediator mediator)
        {
            var command = new DeletarPessoaRequest(id);
            return Task.FromResult(mediator.Send(command));
        }
    }
}