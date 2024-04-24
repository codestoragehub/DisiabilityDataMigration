using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IContractReferenceService
{
    Task<bool> SkipDocumentUploadAsync(int applicationId);
}