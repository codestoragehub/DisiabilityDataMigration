using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.AddressDocuments.Commands.CreateAddressDocument
{
    public class CreateAddressDocumentDto
    {        
        public AddressType AddressType { get; set; }
        public int? AddressId { get; set; }
        public int? DocumentId { get; set; }
    }
}
