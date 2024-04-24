using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileContractReferenceDto : SupplierProfileAddressDto
    {
        public int SupplierProfileContractReferenceId { get; set; }
        public string CompanyOrOrganizationName { get; set; }
        public string BuyerOrRepresentative { get; set; }
        public string ProductOrService { get; set; }
        public decimal DollarValue { get; set; }
        public new int SupplierProfileId { get; set; }
    }
}
