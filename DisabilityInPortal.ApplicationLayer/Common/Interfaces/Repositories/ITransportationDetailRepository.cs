using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ITransportationDetailRepository
{
    Task<TransportationDetail> GetByApplicationIdAsync(int applicationId);
}