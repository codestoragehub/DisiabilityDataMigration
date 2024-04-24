using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Interfaces
{
    public interface IAddress: IAuditBaseEntity
    {
         int AddressId { get; set; }

         string Name { get; set; }

         string Title { get; set; }
         AddressType AddressType { get; set; }

         string Address1 { get; set; }

         string City { get; set; }

         int? StateId { get; set; }
         State State { get; set; }

         string ZipCode { get; set; }

         string ZipCodePlus4 { get; set; }

         int? CountryId { get; set; }
         Country Country { get; set; }

         string Email { get; set; }

         string Phone { get; set; }

         string CellPhone { get; set; }

         string Fax { get; set; }

         string Ext { get; set; }
    }
}
