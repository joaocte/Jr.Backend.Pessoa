using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Libs.Utilities;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CadastrarPessoaUseCase(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.pessoaRepository = pessoaRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            Domain.Pessoa pessoa = cadastrarPessoaRequest.Convert();
            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(pessoa);
            await pessoaRepository.AddAsync(pessoaEntity);

            await unitOfWork.CommitAsync();

            return new CadastrarPessoaRespose
            {
                Id = pessoaEntity.Id.ToGuid()
            };
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

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}