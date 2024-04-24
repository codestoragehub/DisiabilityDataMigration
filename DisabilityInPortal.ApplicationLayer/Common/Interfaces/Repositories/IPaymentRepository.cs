using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<int> CreatePaymentAsync(Payment payment);
}