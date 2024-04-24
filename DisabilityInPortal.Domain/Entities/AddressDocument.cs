using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("AddressDocuments")]
    public class AddressDocument
    {
        public int AddressDocumentId { get; set; }

        public AddressType AddressType { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
