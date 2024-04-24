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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IRepositoryAsync<Vehicle> _repository;

        public VehicleRepository(IRepositoryAsync<Vehicle> repository)
        {
            _repository = repository;
        }

        public Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return _repository.Entities
                .Include(f => f.Document)
                .Where(f => f.VehicleId == vehicleId)
                .FirstOrDefaultAsync();
        }

        public Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            return _repository.AddAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            await _repository.UpdateAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(Vehicle vehicle)
        {
            await _repository.DeleteAsync(vehicle);
        }

        public Task<List<Vehicle>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<Vehicle>> GetListByApplicationIdAsync(int applicationId)
        {
            return _repository.Entities
                 .Include(f => f.Document)
                 .Where(f => f.ApplicationId == applicationId).ToListAsync();
        }

        public Task<Vehicle> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
        }
    }
}
