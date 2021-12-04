using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Domain.Abstractions.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.ObterPessoa
{
    public class ObterPessoaUseCase : IObterPessoaUseCase
    {
        private bool disposedValue;
        private readonly IMapper mapper;
        private readonly IPessoaRepository pessoaRepository;

        public ObterPessoaUseCase(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            this.mapper = mapper;
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<Domain.Pessoa>> ExecuteAsync(ObterPessoaPorIdRequest obterPessoaPorIdRequest)
        {
            var pessoasQueryable = await pessoaRepository.GetAllAsync();

            //var pessoasEntity = pessoasQueryable.Apply(obterPessoaPorIdRequest).ToList();

            if (!pessoasQueryable.Any())
                throw new NotFoundException($"Não foi encontrado uma pessoa para consulta informada.");

            return mapper.Map<IEnumerable<Domain.Pessoa>>(pessoasQueryable);
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