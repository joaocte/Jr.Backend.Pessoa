using AutoMapper;
using Jror.Backend.Message.Events.Pessoa.Events;
using Jror.Backend.Message.Share.Pessoa;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<Infrastructure.Entity.Endereco, Endereco>();
            CreateMap<Infrastructure.Entity.Pessoa, PessoaCadastradaEvent>();
            CreateMap<Infrastructure.Entity.Pessoa, PessoaAtualizadaEvent>();
            CreateMap<Domain.Pessoa, PessoaDeletadaEvent>();
        }
    }
}