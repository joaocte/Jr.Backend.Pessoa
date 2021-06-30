using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Context;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Interfaces;
using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected IMongoCollection<TEntity> _dbSet;

        protected Repository(IMongoContext context, string collectionName)
        {
            this._context = context;

            _dbSet = this._context.GetCollection<TEntity>(collectionName);
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            _context.AddCommand(() => _dbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual async Task RemoveAsync(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }

            _dbSet = null;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}