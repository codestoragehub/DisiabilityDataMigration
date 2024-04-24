using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IFacilityRepository
{
    Task<Facility> GetFacilityByIdAsync(int facilityId);
    Task<Facility> CreateFacilityAsync(Facility facility);
    Task UpdateFacilityAsync(Facility facility);
    Task DeleteFacilityAsync(Facility facility);
    Task<Facility> GetByDocumentIdAsync(int documentId);
}