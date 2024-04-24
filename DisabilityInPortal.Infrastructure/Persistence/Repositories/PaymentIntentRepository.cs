using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class PaymentIntentRepository : IPaymentIntentRepository
{
    private readonly IRepositoryAsync<PaymentIntent> _repository;

    public PaymentIntentRepository(IRepositoryAsync<PaymentIntent> repository)
    {
        _repository = repository;
    }

    public Task<PaymentIntent> GetPaymentIntentByIdAsync(int paymentIntentId)
    {
        return _repository.Entities
            .Include(p => p.Invoice)
            .Where(f => f.PaymentIntentId == paymentIntentId)
            .FirstOrDefaultAsync();
    }
    
    public Task<PaymentIntent> GetPaymentIntentByStripePaymentIntentIdAsync(string stripePaymentIntentId)
    {
        return _repository.Entities
            .Include(p => p.Invoice).ThenInclude(i => i.Application)
            .Where(f => f.StripePaymentIntentId == stripePaymentIntentId)
            .FirstOrDefaultAsync();
    }

    public Task<PaymentIntent> CreatePaymentIntentAsync(PaymentIntent paymentIntent)
    {
        return _repository.AddAsync(paymentIntent);
    }

    public async Task UpdatePaymentIntentAsync(PaymentIntent paymentIntent)
    {
        await _repository.UpdateAsync(paymentIntent);
    }

    public async Task DeletePaymentIntentAsync(PaymentIntent paymentIntent)
    {
        await _repository.DeleteAsync(paymentIntent);
    }
}