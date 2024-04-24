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
    public class LegalStructureDocumentRepository : ILegalStructureDocumentRepository
    {
        private readonly IRepositoryAsync<LegalStructureDocument> _repository;

        public LegalStructureDocumentRepository(IRepositoryAsync<LegalStructureDocument> repository)
        {
            _repository = repository;
        }

        public Task<LegalStructureDocument> GetByIdAsync(int legalStructureDocumentId)
        {
            return _repository.Entities
                .Include(x => x.Document)
                .Include(x=>x.LegalStructure)
                .Where(f => f.LegalStructureDocumentId == legalStructureDocumentId)
                .FirstOrDefaultAsync();
        }

        public Task<LegalStructureDocument> CreateAsync(LegalStructureDocument legalStructureDocument)
        {
            return _repository.AddAsync(legalStructureDocument);
        }

        public async Task UpdateAsync(LegalStructureDocument legalStructureDocument)
        {
            await _repository.UpdateAsync(legalStructureDocument);
        }

        public async Task DeleteAsync(LegalStructureDocument legalStructureDocument)
        {
            await _repository.DeleteAsync(legalStructureDocument);
        }

        public Task<List<LegalStructureDocument>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<LegalStructureDocument>> GetListByLegalStructureIdAsync(int LegalStructureId)
        {
            return _repository.Entities
                .Include(x=>x.Document)
                .Include(x => x.LegalStructure)
                .Where(f => f.LegalStructureId == LegalStructureId).ToListAsync();
        }

        public async Task RemoveRange(IEnumerable<LegalStructureDocument> legalStructureDocumentList)
        {
            await _repository.RemoveRange(legalStructureDocumentList);
        }

        public Task<LegalStructureDocument> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities
                .Include(x => x.Document)
                .Include(x => x.LegalStructure)
                .Where(f => f.DocumentId == documentId)
                .FirstOrDefaultAsync(); ;
        }
    }
}
