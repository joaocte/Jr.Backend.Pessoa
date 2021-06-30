using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class Endereco : Core.ValueObject
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Pais { get; private set; }
        public string Cep { get; private set; }

        public string Complemento { get; private set; }

        public Endereco(string logradouro, string bairro, string numero, string estado, string cidade, string pais, string cep)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            Pais = pais;
            Cep = cep;
        }

        public Endereco(string logradouro, string bairro, string numero, string estado, string cidade, string pais, string cep, string complemento)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            Pais = pais;
            Cep = cep;
            Complemento = complemento;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Logradouro;
            yield return Bairro;
            yield return Numero;
            yield return Estado;
            yield return Cidade;
            yield return Pais;
            yield return Cep;
            yield return Complemento;
        }
    }
}