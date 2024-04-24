using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IRepositoryAsync<Payment> _repository;

    public PaymentRepository(IRepositoryAsync<Payment> repository)
    {
        _repository = repository;
    }

    public async Task<int> CreatePaymentAsync(Payment payment)
    {
        await _repository.AddAsync(payment);
        
        return payment.PaymentId;
    }
}