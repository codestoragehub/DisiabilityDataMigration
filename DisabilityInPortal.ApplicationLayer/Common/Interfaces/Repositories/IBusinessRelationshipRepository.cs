using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IBusinessRelationshipRepository
    {
        Task<BusinessRelationship> GetBusinessRelationshipByIdAsync(int businessRelationshipId);
        Task<BusinessRelationship> CreateBusinessRelationshipAsync(BusinessRelationship businessRelationship);
        Task UpdateBusinessRelationshipAsync(BusinessRelationship businessRelationship);
        Task DeleteBusinessRelationshipAsync(BusinessRelationship businessRelationship);
        Task<List<BusinessRelationship>> GetListByApplicationIdAsync(int applicationId);
        Task<BusinessRelationship> GetByDocumentIdAsync(int documentId);
    }
}
