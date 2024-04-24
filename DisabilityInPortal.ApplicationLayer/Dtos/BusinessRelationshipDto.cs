using DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.BusinessRelationships.Queries.GetBusinessRelationshipById
{
    public class BusinessRelationshipDto : AddressDto
    {
        public int? BusinessRelationshipId { get; set; }
        public bool HasSubsidiariesOrAffiliate { get; set; }
        public int? DocumentId { get; set; }
        public string ExplanationOfOralOrImpliedAgreement { get; set; }
        public string BusinessName { get; set; }
        public int? AdressId { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public new int ApplicationId { get; set; }
    }
}
