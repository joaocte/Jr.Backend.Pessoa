using FluentValidation;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.NomeCompleto).SetValidator(new NomeCompletoValidation());

            RuleFor(p => p.Documentos).SetValidator(new DocumentosValidation());

            RuleForEach(p => p.Enderecos).SetValidator(new EnderecoValidation());
        }
    }
}