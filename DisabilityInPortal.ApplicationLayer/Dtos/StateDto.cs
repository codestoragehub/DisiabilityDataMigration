using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.States.Queries.GetStateById
{
    public class StateDto
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Country Country { get; set; }
    }
}
