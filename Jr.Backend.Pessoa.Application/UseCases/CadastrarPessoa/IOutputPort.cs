using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();

        /// <summary>
        ///     Pessoa cadastrada com sucesso.
        /// </summary>
        void Ok(Domain.Pessoa pessoa);

        /// <summary>
        ///     Pessoa já cadastrada.
        /// </summary>
        void Conflict();
    }
}