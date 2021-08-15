using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Interfaces
{
    public interface IMongoContext : IDisposable
    {
        Task AddCommand(Func<Task> func);

        Task<int> SaveChanges();

        IMongoCollection<T> GetCollection<T>(string name);
    }
}