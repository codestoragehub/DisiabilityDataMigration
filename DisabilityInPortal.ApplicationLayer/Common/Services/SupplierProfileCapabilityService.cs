using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Extensions;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Commands.UpdateApplication;
using DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Commands.UpdateSupplierProfile;
using DisabilityInPortal.Domain.Entities;
//using DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Common.Services
{
    public class SupplierProfileCapabilityService : ISupplierProfileCapabilityService
    {
        private readonly INaicsCodeRepository _naicsCodeRepository;
        private readonly ISicCodeRepository _sicCodeRepository;
        private readonly IUkSicCodeRepository _ukSicCodeRepository;
        private readonly IUnspscCodeRepository _unspscCodeRepository;
        private readonly IUnNumberCodeRepository _unNumberCodeRepository;

        public SupplierProfileCapabilityService(
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

        public async Task UpdateCapabilityAsync(SupplierProfile supplierProfile, UpdateSupplierProfileDto supplierProfileDto)
        {
            supplierProfile.ProfileCapability.ProductServiceDescription = supplierProfileDto.ProfileCapability.ProductServiceDescription;
            supplierProfile.ProfileCapability.GeographicalServiceArea = supplierProfileDto.ProfileCapability.GeographicalServiceArea;
            await UpdateNaicsCodesAsync(supplierProfile, supplierProfileDto.ProfileCapability.NaicsCodes);
            await UpdateSicCodesAsync(supplierProfile, supplierProfileDto.ProfileCapability.SicCodes);
            await UpdateUkSicCodesAsync(supplierProfile, supplierProfileDto.ProfileCapability.UkSicCodes);
            await UpdateUnspscCodesAsync(supplierProfile, supplierProfileDto.ProfileCapability.UnspscCodes);
            await UpdateUnNumberCodesAsync(supplierProfile, supplierProfileDto.ProfileCapability.UnNumberCodes);
        }

        public async Task UpdateNaicsCodesAsync(SupplierProfile supplierProfile, IList<string> naicsCodes)
        {
            supplierProfile.ProfileCapability.NaicsCodes.Clear();

            if (naicsCodes.IsNullOrEmpty())
                return;

            var naicsCodeList = await _naicsCodeRepository.GetListAsync(naicsCodes);
            supplierProfile.ProfileCapability.NaicsCodes.AddRange(naicsCodeList);
        }

        public async Task UpdateSicCodesAsync(SupplierProfile supplierProfile, IList<string> sicCodes)
        {
            supplierProfile.ProfileCapability.SicCodes.Clear();

            if (sicCodes.IsNullOrEmpty())
                return;

            var sicCodeList = await _sicCodeRepository.GetListAsync(sicCodes);
            supplierProfile.ProfileCapability.SicCodes.AddRange(sicCodeList);
        }

        public async Task UpdateUkSicCodesAsync(SupplierProfile supplierProfile, IList<string> ukSicCodes)
        {
            supplierProfile.ProfileCapability.UkSicCodes.Clear();

            if (ukSicCodes.IsNullOrEmpty())
                return;

            var ukSicCodeList = await _ukSicCodeRepository.GetListAsync(ukSicCodes);
            supplierProfile.ProfileCapability.UkSicCodes.AddRange(ukSicCodeList);
        }

        public async Task UpdateUnspscCodesAsync(SupplierProfile supplierProfile, IList<string> unspscCodes)
        {
            supplierProfile.ProfileCapability.UnspscCodes.Clear();

            if (unspscCodes.IsNullOrEmpty())
                return;

            var unspscCodeList = await _unspscCodeRepository.GetListAsync(unspscCodes);
            supplierProfile.ProfileCapability.UnspscCodes.AddRange(unspscCodeList);
        }

        public async Task UpdateUnNumberCodesAsync(SupplierProfile supplierProfile, IList<string> unNumberCodes)
        {
            supplierProfile.ProfileCapability.UnNumberCodes.Clear();

            if (unNumberCodes.IsNullOrEmpty())
                return;

            var unNumberCodeList = await _unNumberCodeRepository.GetListAsync(unNumberCodes);
            supplierProfile.ProfileCapability.UnNumberCodes.AddRange(unNumberCodeList);
        }
    }
}
