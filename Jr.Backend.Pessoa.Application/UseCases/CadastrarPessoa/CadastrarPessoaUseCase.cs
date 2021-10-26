using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Libs.Utilities;
using Jr.Backend.Message.Events.Pessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Domain.Excepitons;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public CadastrarPessoaUseCase(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, IMapper mapper, IBus bus)
        {
            this.pessoaRepository = pessoaRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            Domain.Pessoa pessoa = cadastrarPessoaRequest.Convert();

            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(pessoa.Documentos.Cpf);

            if (pessoaJaCadastrada)
                throw new PessoaJaCadastradaException($"Cpf {pessoa.Documentos.Cpf} Já cadastrado!");

            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(pessoa);

            await pessoaRepository.AddAsync(pessoaEntity);

            await unitOfWork.CommitAsync();

            PessoaCadastradaEvent @event = mapper.Map<PessoaCadastradaEvent>(pessoaEntity);

            await bus.Publish(@event);
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