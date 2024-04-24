using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IDiversityRepository
    {
        Task<Diversity> GetDiversityByIdAsync(int diversityId);
        Task<Diversity> CreateDiversityAsync(Diversity diversity);
        Task UpdateDiversityAsync(Diversity diversity);
        Task DeleteDiversityAsync(Diversity diversity);
        Task<List<Diversity>> GetListAsync();
        Task<List<Diversity>> GetListByApplicationIdAsync(int applicationId);
        Task<Diversity> GetByDocumentIdAsync(int documentId);
    }
}
