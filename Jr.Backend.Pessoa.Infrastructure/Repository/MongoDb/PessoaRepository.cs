using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public class PessoaRepository : MongoRepository<Entity.Pessoa>, IPessoaRepository
    {
        public PessoaRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }

        public async Task<bool> ExistsAsync(string cpf, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Entity.Pessoa>.Filter
        .Eq(z => z.Documentos.Cpf, cpf);
            var data = await _dbSet.FindAsync(filter, null, cancellationToken).ConfigureAwait(false);

            return await data.AnyAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}