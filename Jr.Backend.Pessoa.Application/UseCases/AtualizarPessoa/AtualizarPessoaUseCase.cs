using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IUnitOfWork unitOfWork;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;

        public AtualizarPessoaUseCase(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
        }

        public async Task<AtualizarPessoaResponse> ExecuteAsync(AtualizarPessoaRequest atualizarPessoaRequest)
        {
            Domain.Pessoa pessoa = atualizarPessoaRequest.Convert();
            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(pessoa);

            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(pessoaEntity.Documentos.Cpf)
                && await pessoaRepository.ExistsAsync(pessoaEntity.Id);

            if (!pessoaJaCadastrada)
                throw new NotFoundException($"Cpf {pessoaEntity.Documentos.Cpf} ou Id {pessoaEntity.Id} Não encontrado!");

            await pessoaRepository.UpdateAsync(pessoaEntity);

            await unitOfWork.CommitAsync();

            return new AtualizarPessoaResponse(pessoa.NomeCompleto, pessoa.Enderecos, pessoa.Documentos);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    pessoaRepository?.Dispose();
                    unitOfWork?.Dispose();
                }

                disposedValue = true;
            }
        }

        void System.IDisposable.Dispose()
        {
            Dispose(disposing: true);
        }
    }
}