using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class AddressDocumentRepository: IAddressDocumentsRepository
    {
        private readonly IRepositoryAsync<AddressDocument> _repository;

        public AddressDocumentRepository(IRepositoryAsync<AddressDocument> repository)
        {
            _repository = repository;
        }

        public async Task<List<AddressDocument>> GetListAsync()
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .ToListAsync();                
        }

        public async Task DeleteAsync(AddressDocument addressDocument)
        {
            await _repository.DeleteAsync(addressDocument);
        }

        public async Task<AddressDocument> GetByDocumentIdAsync(int documentId)
        {
            return await _repository.Entities.Where(p => p.DocumentId == documentId).FirstOrDefaultAsync();
        }        

        public async Task<AddressDocument> InsertAsync(AddressDocument addressDocument)
        {
            await _repository.AddAsync(addressDocument);
            return addressDocument;
        }       
    }
}
