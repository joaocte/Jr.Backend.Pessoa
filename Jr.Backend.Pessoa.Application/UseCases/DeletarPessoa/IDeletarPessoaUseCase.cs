using Jr.Backend.Pessoa.Domain.Commands.Requests;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public interface IDeletarPessoaUseCase : IDisposable
    {
        Task<bool> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest);
    }
}