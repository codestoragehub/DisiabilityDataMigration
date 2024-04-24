using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IAddressDocumentsRepository
    {
        Task<List<AddressDocument>> GetListAsync();
        Task<AddressDocument> GetByDocumentIdAsync(int documentId);
        Task<AddressDocument> InsertAsync(AddressDocument addressDocument);
        Task DeleteAsync(AddressDocument addressDocument);
    }
}
