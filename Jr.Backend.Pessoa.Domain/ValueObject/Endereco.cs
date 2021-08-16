using Jr.Backend.Libs.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class Endereco : GenericValueObject
    {
        public string Logradouro { get; }
        public string Bairro { get; }
        public string Numero { get; }
        public string Estado { get; }
        public string Cidade { get; }
        public string Pais { get; }
        public string Cep { get; }

        public string Complemento { get; }

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

        public static implicit operator string(Endereco endereco) => endereco.ToString();

        public override string ToString()
        {
            return $"Logradouro: {Logradouro} Número: {Numero}, Bairro: {Bairro}, Cep: {Cep}, Cidade: {Cidade}, Estado: {Estado}, País: {Pais}";
        }
    }
}