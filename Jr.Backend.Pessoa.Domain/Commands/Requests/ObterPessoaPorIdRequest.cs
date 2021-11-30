using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class ObterPessoaPorIdRequest : IRequest<IEnumerable<Pessoa>>, IQuerySort, IQueryPaging
    {
        public string Cpf { get; set; }
        public Guid Id { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}