using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IDisabilityImpactDocumentRepository
    {
        Task<DisabilityImpactDocument> CreateDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument);
        Task UpdateDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument);
        Task DeleteDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument);
        Task<DisabilityImpactDocument> GetDisabilityImpactDocumentByIdAsync(int disabiltyImpactId);
        Task<DisabilityImpactDocument> GetDisabilityImpactDocumentByDocumentIdAsync(int documentId);
        Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByIdAsync(int disabilityImpactId);
        Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByApplicationIdAsync(int applicationId);
        Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByDocumentTypeAsync(DisabilityImpactDocumentType disabilityImpactDocumentType, int applicationId);
        Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentAllListAsync();
    }
}
