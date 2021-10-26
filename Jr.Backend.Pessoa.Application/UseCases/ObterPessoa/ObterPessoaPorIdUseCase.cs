using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Domain.Excepitons;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.ObterPessoa
{
    public class ObterPessoaPorIdUseCase : IObterPessoaPorIdUseCase
    {
        private bool disposedValue;
        private readonly IMapper mapper;
        private readonly IPessoaRepository pessoaRepository;

        public ObterPessoaPorIdUseCase(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            this.mapper = mapper;
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<ObterPessoaPorIdResponse> ExecuteAsync(ObterPessoaPorIdRequest cadastrarPessoaRequest)
        {
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(cadastrarPessoaRequest.Id);

            if (!pessoaJaCadastrada)
                throw new PessoaNaoCadastradaException($"Id {cadastrarPessoaRequest.Id} Não encontrado!");

            var pessoaEntity = await pessoaRepository.GetByIdAsync(cadastrarPessoaRequest.Id);

            var pessoaDomain = mapper.Map<Domain.Pessoa>(pessoaEntity);

            return new ObterPessoaPorIdResponse(pessoaDomain.NomeCompleto, pessoaDomain.Enderecos, pessoaDomain.Documentos);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    pessoaRepository?.Dispose();
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