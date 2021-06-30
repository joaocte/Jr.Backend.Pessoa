using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.UoW
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        private readonly IMongoContext _context;
        private bool disposedValue;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}