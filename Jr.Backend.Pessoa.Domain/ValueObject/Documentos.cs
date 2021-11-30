using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class Documentos : Jror.Backend.Libs.Domain.Abstractions.ValueObject.ValueObject
    {
        public string Cpf { get; }
        public string Rg { get; }
        public string TituloEleitoral { get; }

        [JsonConstructor]
        public Documentos(string cpf, string rg, string tituloEleitoral)
        {
            Cpf = cpf;
            Rg = rg;
            TituloEleitoral = tituloEleitoral;
        }

        public Documentos(string cpf)
        {
            Cpf = cpf;
        }

        public Documentos(string cpf, string rg) : this(cpf)
        {
            Rg = rg;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Cpf;
            yield return Rg;
            yield return TituloEleitoral;
        }
    }
}