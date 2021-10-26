using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public interface ICadastrarPessoaUseCase : IDisposable
    {
        Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest);
    }
}