using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.ObterPessoa
{
    public interface IObterPessoaPorIdUseCase : IDisposable
    {
        Task<ObterPessoaPorIdResponse> ExecuteAsync(ObterPessoaPorIdRequest cadastrarPessoaRequest);
    }
}