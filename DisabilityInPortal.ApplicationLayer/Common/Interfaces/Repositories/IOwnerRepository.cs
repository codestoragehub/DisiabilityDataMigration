using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetListAsyncByApplicationId(int applicationId);
        Task<Owner> GetOwnerByIdAsync(int ownerId);
        Task<Owner> CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(Owner owner);
        Task<Owner> GetByDocumentIdAsync(int documentId);
    }
}
