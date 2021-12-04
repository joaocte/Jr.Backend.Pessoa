using Jr.Backend.Pessoa.Domain.Commands.Requests;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public interface IDeletarPessoaUseCase : IDisposable
    {
        Task<Unit> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest, CancellationToken cancellationToken = default);
    }
}