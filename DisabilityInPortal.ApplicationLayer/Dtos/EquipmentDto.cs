using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.Equipments.Queries.GetEquipmentById
{
    public class EquipmentDto
    {
        public int? EquipmentId { get; set; }
        public string EquipmentType { get; set; }
        public OwnershipType Ownership { get; set; }
        public decimal RentalAmount { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentUsed { get; set; }
        public UsedType EquipmentUsedType { get; set; }
        public int? DocumentId { get; set; }
        public int ApplicationId { get; set; }
    }
}
