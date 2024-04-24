using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class PaymentDetailRepository : IPaymentDetailRepository
{
    private readonly IRepositoryAsync<PaymentDetail> _repository;

    public PaymentDetailRepository(IRepositoryAsync<PaymentDetail> repository)
    {
        _repository = repository;
    }

    public async Task UpdatePaymentDetailAsync(PaymentDetail paymentDetail)
    {
        await _repository.UpdateAsync(paymentDetail);
    }
}