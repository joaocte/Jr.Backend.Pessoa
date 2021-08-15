using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Api.UseCases.V1.Pessoa.Cadastrar
{
    public sealed class Pessoa : ControllerBase, IOutputPort
    {
        private IActionResult _viewModel;

        public new void Conflict() => this._viewModel = base.Conflict();

        public void Invalid() => this._viewModel = this.BadRequest();

        public void Ok(Domain.Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}