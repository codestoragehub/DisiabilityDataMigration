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
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IRepositoryAsync<Document> _repository;

        public DocumentRepository(IRepositoryAsync<Document> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(Document document)
        {
            await _repository.DeleteAsync(document);
        }

        public Task<Document> GetByIdAsync(int documentId)
        {
            return _repository.GetByIdAsync(documentId);
        }

        public Task<List<Document>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Document> InsertAsync(Document document)
        {
            return _repository.AddAsync(document);
        }

        public Task UpdateAsync(Document document)
        {
            return _repository.UpdateAsync(document);
        }
    }
}
