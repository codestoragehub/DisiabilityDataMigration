using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Extensions;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Commands.UpdateApplication;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class CapabilityService : ICapabilityService
{
    private readonly INaicsCodeRepository _naicsCodeRepository;
    private readonly ISicCodeRepository _sicCodeRepository;
    private readonly IUkSicCodeRepository _ukSicCodeRepository;
    private readonly IUnspscCodeRepository _unspscCodeRepository;
    private readonly IUnNumberCodeRepository _unNumberCodeRepository;

    public CapabilityService(
        INaicsCodeRepository naicsCodeRepository,
        ISicCodeRepository sicCodeRepository,
        IUkSicCodeRepository ukSicCodeRepository,
        IUnspscCodeRepository unspscCodeRepository, 
        IUnNumberCodeRepository unNumberCodeRepository)
    {
        _naicsCodeRepository = naicsCodeRepository;
        _sicCodeRepository = sicCodeRepository;
        _ukSicCodeRepository = ukSicCodeRepository;
        _unspscCodeRepository = unspscCodeRepository;
        _unNumberCodeRepository = unNumberCodeRepository;
    }

    public async Task UpdateCapabilityAsync(Application application, UpdateApplicationDto applicationDto)
    {
        application.Capability.ProductServiceDescription = applicationDto.Capability.ProductServiceDescription;
        application.Capability.GeographicalServiceArea = applicationDto.Capability.GeographicalServiceArea;
        await UpdateNaicsCodesAsync(application, applicationDto.Capability.NaicsCodes);
        await UpdateSicCodesAsync(application, applicationDto.Capability.SicCodes);
        await UpdateUkSicCodesAsync(application, applicationDto.Capability.UkSicCodes);
        await UpdateUnspscCodesAsync(application, applicationDto.Capability.UnspscCodes);
        await UpdateUnNumberCodesAsync(application, applicationDto.Capability.UnNumberCodes);
    }

    public async Task UpdateNaicsCodesAsync(Application application, IList<string> naicsCodes)
    {
        application.Capability.NaicsCodes.Clear();

        if (naicsCodes.IsNullOrEmpty())
            return;

        var naicsCodeList = await _naicsCodeRepository.GetListAsync(naicsCodes);
        application.Capability.NaicsCodes.AddRange(naicsCodeList);
    }

    public async Task UpdateSicCodesAsync(Application application, IList<string> sicCodes)
    {
        application.Capability.SicCodes.Clear();

        if (sicCodes.IsNullOrEmpty())
            return;

        var sicCodeList = await _sicCodeRepository.GetListAsync(sicCodes);
        application.Capability.SicCodes.AddRange(sicCodeList);
    }

    public async Task UpdateUkSicCodesAsync(Application application, IList<string> ukSicCodes)
    {
        application.Capability.UkSicCodes.Clear();

        if (ukSicCodes.IsNullOrEmpty())
            return;

        var ukSicCodeList = await _ukSicCodeRepository.GetListAsync(ukSicCodes);
        application.Capability.UkSicCodes.AddRange(ukSicCodeList);
    }

    public async Task UpdateUnspscCodesAsync(Application application, IList<string> unspscCodes)
    {
        application.Capability.UnspscCodes.Clear();

        if (unspscCodes.IsNullOrEmpty())
            return;

        var unspscCodeList = await _unspscCodeRepository.GetListAsync(unspscCodes);
        application.Capability.UnspscCodes.AddRange(unspscCodeList);
    }
    
    public async Task UpdateUnNumberCodesAsync(Application application, IList<string> unNumberCodes)
    {
        application.Capability.UnNumberCodes.Clear();

        if (unNumberCodes.IsNullOrEmpty())
            return;

        var unNumberCodeList = await _unNumberCodeRepository.GetListAsync(unNumberCodes);
        application.Capability.UnNumberCodes.AddRange(unNumberCodeList);
    }
}