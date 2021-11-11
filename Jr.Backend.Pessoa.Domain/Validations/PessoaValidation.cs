using FluentValidation;

namespace Jr.Backend.Pessoa.Domain.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.NomeCompleto).SetValidator(new NomeCompletoValidacoes());

            RuleFor(p => p.Documentos).SetValidator(new DocumentosValidacoes());

            RuleForEach(p => p.Enderecos).SetValidator(new EnderecoValidacoes());
        }
    }
}