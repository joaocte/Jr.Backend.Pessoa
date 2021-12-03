using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.EntityFramework.Repository;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb
{
    public class EnderecoRepository : Repository<Entity.Endereco, ApplicationDbContext>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}