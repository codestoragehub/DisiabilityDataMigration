using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileAddressDto
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public AddressType AddressType { get; set; }

        public string Address1 { get; set; }
        public string City { get; set; }

        public int? StateId { get; set; }
        public State State { get; set; }

        public string ZipCode { get; set; }
        public string ZipCodePlus4 { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string UserId { get; set; }
        public string Ext { get; set; }
        public int SupplierProfileId { get; set; }
    }
}
