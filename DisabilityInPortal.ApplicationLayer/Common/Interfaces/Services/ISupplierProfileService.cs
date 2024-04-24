using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface ISupplierProfileService
    {
        Task<SupplierProfile> CreateSupplierProfileAsync(int applicationId);
        Task<bool> IsSupplierProfileExistByUserIdAsync(string userId);
        Task<bool> IsSupplierProfileExistByApplicationIdAsync(int applicationId);
    }
}
