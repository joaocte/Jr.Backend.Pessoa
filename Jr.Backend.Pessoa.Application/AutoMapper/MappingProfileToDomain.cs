using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<Infrastructure.Entity.Endereco, Endereco>();
            CreateMap<Infrastructure.Entity.Pessoa, Domain.Pessoa>();
            CreateMap<PessoaResquest, Domain.Pessoa>();
            CreateMap<CadastrarPessoaRequest, Domain.Pessoa>();
        }
    }
}