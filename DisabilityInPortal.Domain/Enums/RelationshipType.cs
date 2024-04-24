using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum RelationshipType
    {
        [Display(Name = "Parent")]
        ParentRelationship = 1,
        
        [Display(Name = "Affiliate")]
        AffiliateRelationship = 2,
        
        [Display(Name = "Subsidiary")]
        SubsidiaryRelationship = 3,        
    }
}
