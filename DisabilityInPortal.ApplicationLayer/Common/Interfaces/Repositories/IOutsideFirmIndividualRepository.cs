using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IOutsideFirmIndividualRepository
{
    Task<OutsideFirmIndividual> GetOutsideFirmIndividualByIdAsync(int outsideFirmIndividualId);
    Task<OutsideFirmIndividual> CreateOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual);
    Task UpdateOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual);
    Task DeleteOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual);
    Task<OutsideFirmIndividual> GetByDocumentIdAsync(int documentId);
    Task<bool> ExistsByOwnerId(int ownerId);
}