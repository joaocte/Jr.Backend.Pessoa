using Jr.Backend.Libs.Infrastructure.Repository.MongoDb;
using Jr.Backend.Libs.Infrastructure.Repository.MongoDb.Interfaces;
using Jr.Backend.Pessoa.Domain;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public class PessoaRepository : MongoRepository<Domain.Pessoa>, IPessoaRepository
    {
        public PessoaRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}