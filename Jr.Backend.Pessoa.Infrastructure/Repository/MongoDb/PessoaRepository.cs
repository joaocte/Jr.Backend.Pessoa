using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.Repository;
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