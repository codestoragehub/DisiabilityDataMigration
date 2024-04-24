using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class BusinessRelationshipRepository : IBusinessRelationshipRepository
    {
        private readonly IRepositoryAsync<BusinessRelationship> _repository;

        public BusinessRelationshipRepository(IRepositoryAsync<BusinessRelationship> repository)
        {
            _repository = repository;
        }

        public Task<BusinessRelationship> GetBusinessRelationshipByIdAsync(int businessRelationshipId)
        {
            return _repository.Entities
                .Include(f => f.Address)
                .Include(f => f.Document)
                .Where(f => f.BusinessRelationshipId == businessRelationshipId)
                .FirstOrDefaultAsync();
        }

        public Task<BusinessRelationship> CreateBusinessRelationshipAsync(BusinessRelationship businessRelationship)
        {
            return _repository.AddAsync(businessRelationship);
        }

        public async Task UpdateBusinessRelationshipAsync(BusinessRelationship businessRelationship)
        {
            await _repository.UpdateAsync(businessRelationship);
        }

        public async Task DeleteBusinessRelationshipAsync(BusinessRelationship businessRelationship)
        {
            await _repository.DeleteAsync(businessRelationship);
        }

        public Task<List<BusinessRelationship>> GetListByApplicationIdAsync(int applicationId)
        {
            return _repository.Entities
                .Include(f => f.Address)
                .Include(f => f.Document)
                .Where(f => f.ApplicationId == applicationId).ToListAsync();
        }

        public Task<BusinessRelationship> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
        }
    }
}