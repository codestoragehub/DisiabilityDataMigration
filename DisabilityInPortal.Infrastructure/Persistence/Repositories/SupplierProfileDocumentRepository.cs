using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class SupplierProfileDocumentRepository : ISupplierProfileDocumentRepository
    {
        private readonly IRepositoryAsync<SupplierProfileDocument> _repository;

        public SupplierProfileDocumentRepository(IRepositoryAsync<SupplierProfileDocument> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(SupplierProfileDocument document)
        {
            await _repository.DeleteAsync(document);
        }

        public Task<SupplierProfileDocument> GetByIdAsync(int documentId)
        {
            return _repository.GetByIdAsync(documentId);
        }

        public Task<List<SupplierProfileDocument>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<SupplierProfileDocument> InsertAsync(SupplierProfileDocument document)
        {
            return _repository.AddAsync(document);
        }

        public Task UpdateAsync(SupplierProfileDocument document)
        {
            return _repository.UpdateAsync(document);
        }
    }
}
