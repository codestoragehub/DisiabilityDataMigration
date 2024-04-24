using System.Threading;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit(CancellationToken cancellationToken = default);
    }
}