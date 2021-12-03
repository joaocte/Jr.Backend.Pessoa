using Jr.Backend.Pessoa.Domain.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.ObterPessoa
{
    public interface IObterPessoaUseCase : IDisposable
    {
        Task<IEnumerable<Domain.Pessoa>> ExecuteAsync(ObterPessoaPorIdRequest obterPessoaPorIdRequest);
    }
}