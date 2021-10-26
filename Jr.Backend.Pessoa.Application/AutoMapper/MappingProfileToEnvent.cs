using AutoMapper;
using Jr.Backend.Message.Events.Pessoa;
using Jr.Backend.Message.Events.Pessoa.Dto;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<Infrastructure.Entity.Endereco, Endereco>();
            CreateMap<Infrastructure.Entity.Documentos, Documentos>();
            CreateMap<Infrastructure.Entity.NomeCompleto, NomeCompleto>();
            CreateMap<Infrastructure.Entity.Pessoa, PessoaCadastradaEvent>();
        }
    }
}