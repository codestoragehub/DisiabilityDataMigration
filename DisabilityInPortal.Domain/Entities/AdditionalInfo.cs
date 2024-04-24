using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    public class AdditionalInfo
    {
        public int AdditionalInfoId { get; set; }
        public string Field_Title { get; set; }
        public string Description { get; set; }
        public bool IsUploadRequired { get; set; }
        public int? DoumentID { get; set; }
        public int SupplierProfileId { get; set; }
        public string UserId { get; set; }
    }
}
