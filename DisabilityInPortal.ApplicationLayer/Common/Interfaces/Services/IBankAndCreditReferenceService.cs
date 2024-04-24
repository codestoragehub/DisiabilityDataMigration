using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IBankAndCreditReferenceService
{
    Task<bool> SkipDocumentUploadAsync(int applicationId);
}