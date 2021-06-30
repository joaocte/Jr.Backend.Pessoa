using FluentValidation;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class EnderecoValidacoes : AbstractValidator<Endereco>
    {
        public EnderecoValidacoes()
        {
            RuleFor(p => p.Bairro)
                .NotEmpty().NotNull().WithMessage("Bairro deve ser informado");

            RuleFor(p => p.Cep)
                .NotEmpty().NotNull().WithMessage("Cep deve ser informado");

            RuleFor(p => p.Cidade)
                .NotEmpty().NotNull().WithMessage("Cidade deve ser informado");

            RuleFor(p => p.Estado)
                .NotEmpty().NotNull().WithMessage("Estado deve ser informado");

            RuleFor(p => p.Logradouro)
                .NotEmpty().NotNull().WithMessage("Logradouro deve ser informado");

            RuleFor(p => p.Numero)
                .NotEmpty().NotNull().WithMessage("Numero deve ser informado");

            RuleFor(p => p.Pais)
                .NotEmpty().NotNull().WithMessage("País deve ser informado");
        }
    }
}