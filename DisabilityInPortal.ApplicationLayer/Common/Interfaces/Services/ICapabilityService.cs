using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Commands.UpdateApplication;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface ICapabilityService
{
    Task UpdateCapabilityAsync(Application application, UpdateApplicationDto applicationDto);
    Task UpdateNaicsCodesAsync(Application application, IList<string> naicsCodes);
    Task UpdateSicCodesAsync(Application application, IList<string> sicCodes);
    Task UpdateUkSicCodesAsync(Application application, IList<string> ukSicCodes);
    Task UpdateUnspscCodesAsync(Application application, IList<string> unspscCodes);
    Task UpdateUnNumberCodesAsync(Application application, IList<string> unNumberCodes);
}