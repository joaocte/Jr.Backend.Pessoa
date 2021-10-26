using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Pessoa.Domain;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IUnitOfWork unitOfWork;

        public CadastrarPessoaUseCase(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
        {
            this.pessoaRepository = pessoaRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            Domain.Pessoa pessoa = cadastrarPessoaRequest.Convert();
            await pessoaRepository.AddAsync(pessoa);

            await unitOfWork.CommitAsync();

            return new CadastrarPessoaRespose
            {
                Id = pessoa.Id
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CadastrarPessoaUseCase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}