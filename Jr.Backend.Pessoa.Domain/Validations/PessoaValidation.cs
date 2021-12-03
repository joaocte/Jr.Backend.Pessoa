using FluentValidation;
using Jror.Backend.Libs.Domain.Core.Validations;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Nome deve ser informado");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().NotNull()
                .WithMessage("O Sobrenome deve ser informado");

            RuleFor(p => p.Rg)
                .NotEmpty()
                .NotNull()
                .WithMessage("Rg deve ser informado");

            RuleFor(p => p.Cpf)
                .NotEmpty()
                .NotNull()
                .CpfValido()
                .WithMessage("Cpf deve ser informado ou é Inválido");

            RuleForEach(p => p.Enderecos).SetValidator(new EnderecoValidation());
        }
    }
}