using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IManagementAtOutsideFirmService
{
    Task<bool> SkipDocumentUploadAsync(int applicationId);
}