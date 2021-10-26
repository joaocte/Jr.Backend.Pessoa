using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Jr.Backend.Pessoa.Domain.Excepitons
{
    public class PessoaJaCadastradaException : AlreadyRegisteredException
    {
        public PessoaJaCadastradaException(string message) : base(message)
        {
        }

        public PessoaJaCadastradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PessoaJaCadastradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}