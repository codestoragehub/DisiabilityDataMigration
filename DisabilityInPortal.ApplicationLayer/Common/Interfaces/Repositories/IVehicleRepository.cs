using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByIdAsync(int equipmentId);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetListAsync();
        Task<List<Vehicle>> GetListByApplicationIdAsync(int applicationId);
        Task<Vehicle> GetByDocumentIdAsync(int documentId);
    }
}
