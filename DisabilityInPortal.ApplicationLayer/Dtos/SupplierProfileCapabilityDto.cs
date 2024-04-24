using DisabilityInPortal.ApplicationLayer.Features.Codes.Dtos;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileCapabilityDto
    {
        public int SupplierProfileCapabilityId { get; set; }
        public string ProductServiceDescription { get; set; }
        public GeographicalServiceAreaType GeographicalServiceArea { get; set; }
        public List<string> NaicsCodes { get; set; }
        public List<CodeDto> NaicsCodeDtos { get; set; }
        public List<string> SicCodes { get; set; }
        public List<CodeDto> SicCodeDtos { get; set; }
        public List<string> UkSicCodes { get; set; }
        public List<CodeDto> UkSicCodeDtos { get; set; }
        public List<string> UnspscCodes { get; set; }
        public List<CodeDto> UnspscCodeDtos { get; set; }
        public List<string> UnNumberCodes { get; set; }
        public List<CodeDto> UnNumberCodeDtos { get; set; }

        public int SupplierProfileId { get; set; }
        public string UserId { get; set; }
    }
}
