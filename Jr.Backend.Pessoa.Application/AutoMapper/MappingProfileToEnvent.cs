using AutoMapper;
using Jr.Backend.Message.Events.Pessoa;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<Infrastructure.Entity.Endereco, Endereco>();

            CreateMap<Infrastructure.Entity.Pessoa, PessoaCadastradaEvent>()
                .ForMember(dest => dest.Enderecos, m => m.MapFrom(source => source.Enderecos))
                .ForMember(dest => dest.Nome, m => m.MapFrom(source => source.NomeCompleto.Nome))
                .ForMember(dest => dest.Sobrenome, m => m.MapFrom(source => source.NomeCompleto.Sobrenome))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(source => source.Documentos.Cpf))
                .ForMember(dest => dest.Rg, m => m.MapFrom(source => source.Documentos.Rg))
                .ForMember(dest => dest.TituloEleitoral, m => m.MapFrom(source => source.Documentos.TituloEleitoral)).ReverseMap();
        }
    }
}