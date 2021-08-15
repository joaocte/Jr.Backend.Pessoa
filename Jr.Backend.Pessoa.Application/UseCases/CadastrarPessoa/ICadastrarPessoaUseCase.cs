using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public interface ICadastrarPessoaUseCase : IDisposable
    {
        Task ExecuteAsync();

        void SetOutputPort(IOutputPort outputPort);
    }
}