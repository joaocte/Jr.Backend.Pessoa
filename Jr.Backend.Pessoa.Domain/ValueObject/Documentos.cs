using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class Documentos : Core.ValueObject
    {
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string TituloEleitoral { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Cpf;
            yield return Rg;
            yield return TituloEleitoral;
        }
    }
}