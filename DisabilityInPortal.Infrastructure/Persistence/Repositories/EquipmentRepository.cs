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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IRepositoryAsync<Equipment> _repository;

        public EquipmentRepository(IRepositoryAsync<Equipment> repository)
        {
            _repository = repository;
        }

        public Task<Equipment> GetEquipmentByIdAsync(int equipmentId)
        {
            return _repository.Entities
                .Include(f => f.Document)
                .Where(f => f.EquipmentId == equipmentId)
                .FirstOrDefaultAsync();
        }

        public Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            return _repository.AddAsync(equipment);
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            await _repository.UpdateAsync(equipment);
        }

        public async Task DeleteEquipmentAsync(Equipment equipment)
        {
            await _repository.DeleteAsync(equipment);
        }

        public Task<List<Equipment>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<Equipment>> GetListByApplicationIdAsync(int applicationId)
        {
            return _repository.Entities
                .Include(f => f.Document)
                .Where(f => f.ApplicationId == applicationId).ToListAsync();
        }
        public Task<Equipment> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
        }
    }
}
