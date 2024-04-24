using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class DisabilityImpactDocumentRepository : IDisabilityImpactDocumentRepository
    {
        private readonly IRepositoryAsync<DisabilityImpactDocument> _repository;

        public DisabilityImpactDocumentRepository(IRepositoryAsync<DisabilityImpactDocument> repository)
        {
            _repository = repository;
        }

        public async Task<DisabilityImpactDocument> CreateDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument)
        {
            await _repository.AddAsync(disabiltyImpactDocument);
            return disabiltyImpactDocument;
        }

        public async Task UpdateDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument)
        {
            await _repository.UpdateAsync(disabiltyImpactDocument);
        }

        public async Task DeleteDisabilityImpactDocumentAsync(DisabilityImpactDocument disabiltyImpactDocument)
        {
            await _repository.DeleteAsync(disabiltyImpactDocument); ;
        }
        public async Task<DisabilityImpactDocument> GetDisabilityImpactDocumentByIdAsync(int disabilityImpactDocumentId)
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .Where(p => p.DisabilityImpactDocumentId == disabilityImpactDocumentId).FirstOrDefaultAsync();
        }

        public async Task<DisabilityImpactDocument> GetDisabilityImpactDocumentByDocumentIdAsync(int documentId)
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .Where(p => p.DocumentId == documentId).FirstOrDefaultAsync();
        }

        public async Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByIdAsync(int disabilityImpactId)
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .Where(x => x.DisabilityImpactId == disabilityImpactId).ToListAsync();
        }
        public async Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .Where(x => x.ApplicationId == applicationId).ToListAsync();
        }
        public async Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentListByDocumentTypeAsync
            (DisabilityImpactDocumentType disabilityImpactDocumentType, int applicationId)
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .Where(x => x.DisabilityImpactDocumentType == disabilityImpactDocumentType
                 && x.ApplicationId == applicationId).ToListAsync();
        }
        public async Task<List<DisabilityImpactDocument>> GetDisabilityImpactDocumentAllListAsync()
        {
            return await _repository.Entities
                .Include(a => a.Document)
                .ToListAsync();
        }
    }
}
