using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.Codes.Dtos;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Dtos;

public class CapabilityDto
{
    public int CapabilityId { get; set; }
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
}