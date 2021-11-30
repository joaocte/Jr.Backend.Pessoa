using FluentValidation;
using Jr.Backend.Pessoa.Domain.ValueObject;
using Jror.Backend.Libs.Domain.Core.Validations;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class DocumentosValidation : AbstractValidator<Documentos>
    {
        public DocumentosValidation()
        {
            RuleFor(p => p.Rg)
                .NotEmpty()
                .NotNull()
                .WithMessage("Rg deve ser informado");

            RuleFor(p => p.Cpf)
                .NotEmpty()
                .NotNull()
                .CpfValido()
                .WithMessage("Cpf deve ser informado ou é Inválido");
        }
    }
}