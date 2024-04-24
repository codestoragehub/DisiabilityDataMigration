using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task DeleteAsync(Document application);
        Task<Document> GetByIdAsync(int documentId);
        Task<List<Document>> GetListAsync();
        Task<Document> InsertAsync(Document application);
        Task UpdateAsync(Document application);
    }
}