using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}