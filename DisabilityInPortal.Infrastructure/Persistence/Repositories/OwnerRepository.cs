using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IRepositoryAsync<Owner> _repository;

        public OwnerRepository(IRepositoryAsync<Owner> repository)
        {
            _repository = repository;
        }
        public async Task<List<Owner>> GetListAsyncByApplicationId(int applicationId)
        {
            return await _repository.Entities.Where(x => x.ApplicationId == applicationId).ToListAsync();
        }

        public Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            return _repository.Entities                
                .Where(o => o.OwnerId == ownerId)
                .FirstOrDefaultAsync();
        }

        public Task<Owner> CreateOwnerAsync(Owner owner)
        {
           return _repository.AddAsync(owner);            
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            await _repository.UpdateAsync(owner);
        }
        
        public async Task DeleteOwnerAsync(Owner owner)
        {
            await _repository.DeleteAsync(owner);
        }

        public Task<Owner> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(o => o.DocumentId == documentId);
        }
    }
}
