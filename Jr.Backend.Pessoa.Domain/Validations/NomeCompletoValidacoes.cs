using FluentValidation;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class NomeCompletoValidacoes : AbstractValidator<NomeCompleto>
    {
        public NomeCompletoValidacoes()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Nome deve ser informado");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().NotNull()
                .WithMessage("O Sobrenome deve ser informado");
        }
    }
}