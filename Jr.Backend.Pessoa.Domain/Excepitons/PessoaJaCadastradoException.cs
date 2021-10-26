using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Jr.Backend.Pessoa.Domain.Excepitons
{
    public class PessoaJaCadastradoException : AlreadyRegisteredException
    {
        public PessoaJaCadastradoException(string message) : base(message)
        {
        }

        public PessoaJaCadastradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PessoaJaCadastradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}