using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Models
{
    public class SearchQueryResult
    {
        public int ApplicationId { get; set; }
        public string SupplierName { get; set; }
        public string UserName { get; set; }
    }
}
