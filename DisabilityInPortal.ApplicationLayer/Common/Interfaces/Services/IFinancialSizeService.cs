using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface IFinancialSizeService
    {
        Task<bool> SkipDocumentUploadAsync(int applicationId);
    }
}
