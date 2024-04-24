using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ILegalStructureDocumentRepository
    {
        Task<LegalStructureDocument> GetByIdAsync(int legalStructureDocumentId);
        Task<LegalStructureDocument> CreateAsync(LegalStructureDocument legalStructureDocument);
        Task UpdateAsync(LegalStructureDocument legalStructureDocument);
        Task DeleteAsync(LegalStructureDocument legalStructureDocument);
        Task<LegalStructureDocument> GetByDocumentIdAsync(int documentId);
        Task<List<LegalStructureDocument>> GetListAsync();
        Task<List<LegalStructureDocument>> GetListByLegalStructureIdAsync(int legalStructureId);
    }
}
