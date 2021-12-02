using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.EntityFramework.Repository;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public class PessoaRepository : Repository<Entity.Pessoa, ApplicationDbContext>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}