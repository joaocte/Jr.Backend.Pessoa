using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Interfaces
{
    public interface IPessoaRepository : IRepository<Entity.Pessoa>
    {
        Task<bool> ExistsAsync(string Cpf, CancellationToken cancellationToken = default);
    }
}