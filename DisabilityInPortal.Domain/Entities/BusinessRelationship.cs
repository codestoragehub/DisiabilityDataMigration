using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("BusinessRelationships")]
    public class BusinessRelationship
    {
        public int BusinessRelationshipId { get; set; }
        public bool HasSubsidiariesOrAffiliate { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }       

        [StringLength(500)]
        public string ExplanationOfOralOrImpliedAgreement { get; set; }

        [StringLength(200)]
        public string BusinessName { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
