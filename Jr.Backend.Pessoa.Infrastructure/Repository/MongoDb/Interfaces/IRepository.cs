using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task AddAsync(T obj);

        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateAsync(T obj);

        Task RemoveAsync(string id);
    }
}