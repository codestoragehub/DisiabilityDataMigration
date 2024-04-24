using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface ILegalStructureService
    {
        Task<bool> SkipDocumentUploadAsync(int applicationId);
    }
}
