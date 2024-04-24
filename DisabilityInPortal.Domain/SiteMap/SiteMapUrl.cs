using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.SiteMap
{
    public class SiteMapUrl
    {
        public string Url { get; set; }
        public DateTime? Modified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public double? Priority { get; set; }
    }
}
