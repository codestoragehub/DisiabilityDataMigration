using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ICertificationAgencyRepository
    {
        Task<List<CertificationAgency>> GetListAsync();
    }
}