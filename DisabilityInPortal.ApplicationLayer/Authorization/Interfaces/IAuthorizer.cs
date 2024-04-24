using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Authorization.Interfaces
{
    public interface IAuthorizer<T>
    {
        IEnumerable<IAuthorizationRequirement> Requirements { get; }
        void BuildPolicy(T instance);
    }
}