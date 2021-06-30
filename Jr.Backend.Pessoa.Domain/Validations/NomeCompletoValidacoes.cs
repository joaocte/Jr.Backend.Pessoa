using FluentValidation;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    internal class NomeCompletoValidacoes : AbstractValidator<NomeCompleto>
    {
        public NomeCompletoValidacoes()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Nome deve ser informado");

            RuleFor(p => p.Sobrenome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sobrenome deve ser informado");
        }
    }
}