using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Jr.Backend.Pessoa.Domain.Excepitons
{
    public class PessoaNaoCadastradaException : NotFoundException
    {
        public PessoaNaoCadastradaException(string message) : base(message)
        {
        }

        public PessoaNaoCadastradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PessoaNaoCadastradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}