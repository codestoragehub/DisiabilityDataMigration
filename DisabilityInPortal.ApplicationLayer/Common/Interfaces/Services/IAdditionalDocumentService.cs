using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IAdditionalDocumentService
{
    Task<bool> IsDefenceFormDocumentRequiredAsync(int applicationId);
    Task<bool> IsBusinessPlanDocumentRequiredAsync(int applicationId);
}