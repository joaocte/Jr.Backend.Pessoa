using AutoMapper;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<Infrastructure.Entity.Endereco, Endereco>();
            CreateMap<Infrastructure.Entity.Documentos, Documentos>();
            CreateMap<Infrastructure.Entity.NomeCompleto, NomeCompleto>();
            CreateMap<Infrastructure.Entity.Pessoa, Domain.Pessoa>();
        }
    }
}