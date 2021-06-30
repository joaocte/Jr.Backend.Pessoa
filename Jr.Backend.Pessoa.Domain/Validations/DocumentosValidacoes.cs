using FluentValidation;
using Jr.Backend.Pessoa.Domain.Validations.Core;
using Jr.Backend.Pessoa.Domain.ValueObject;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class DocumentosValidacoes : AbstractValidator<Documentos>
    {
        public DocumentosValidacoes()
        {
            RuleFor(p => p.Rg)
                .NotEmpty().NotNull().WithMessage("Rg deve ser informado");

            RuleFor(p => p.Cpf).CpfValido();
        }
    }
}