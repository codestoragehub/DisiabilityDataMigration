using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.AddressDocuments.Queries.GetAddressDocumentList
{
    public class AddressDocumentDto
    {
        public int AddressDocumentId { get; set; }
        public AddressType AddressType { get; set; }
        public int? AddressId { get; set; }        
        public int? DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
