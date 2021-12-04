using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public class PessoaRepository : Repository<Entity.Pessoa>, IPessoaRepository
    {
        public PessoaRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}