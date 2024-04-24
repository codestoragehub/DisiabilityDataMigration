using System.Threading;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Authorization.Models;

namespace DisabilityInPortal.ApplicationLayer.Authorization.Interfaces
{
    public interface IAuthorizationHandler<TRequirement>
        where TRequirement : IAuthorizationRequirement
    {
        Task<AuthorizationResult> Handle(TRequirement requirement, CancellationToken cancellationToken = default);
    }
}