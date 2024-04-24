using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateOrUpdateVehicleDto
    {
        public int? VehicleId { get; set; }
        public string VehicleLicensePlateId { get; set; }
        public OwnershipType Ownership { get; set; }
        
        public string VehicleUsed { get; set; }
        public UsedType VehicleUsedType { get; set; }
        public int? DocumentId { get; set; }
        public int ApplicationId { get; set; }
        public VehicleOwnershipType VOwnership { get; set; }
    }
}
