using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ILegalStructureRepository
    {
        Task<LegalStructure> GetLegalStructureByIdAsync(int legalStructureId);       
        Task<LegalStructure> CreateLegalStructureAsync(LegalStructure legalStructure);
        Task UpdateLegalStructureAsync(LegalStructure legalStructure);
        Task DeleteLegalStructureAsync(LegalStructure legalStructure);
        Task<List<LegalStructure>> GetListAsync();
        Task<List<LegalStructure>> GetListByApplicationIdAsync(int applicationId);
        Task<List<LegalStructure>> GetListByCompanyIdAsync(int companyId);
    }
}
