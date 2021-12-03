using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<Endereco, Infrastructure.Entity.Endereco>();
            CreateMap<Domain.Pessoa, Infrastructure.Entity.Pessoa>();
            CreateMap<AtualizarPessoaRequest, Infrastructure.Entity.Pessoa>();
        }
    }
}