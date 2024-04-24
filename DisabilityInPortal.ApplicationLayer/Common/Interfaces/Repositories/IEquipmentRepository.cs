using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IEquipmentRepository
    {
        Task<Equipment> GetEquipmentByIdAsync(int equipmentId);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(Equipment equipment);
        Task<List<Equipment>> GetListAsync();
        Task<List<Equipment>> GetListByApplicationIdAsync(int applicationId);
        Task<Equipment> GetByDocumentIdAsync(int documentId);
    }
}
