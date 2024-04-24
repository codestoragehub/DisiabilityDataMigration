using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IPaymentIntentRepository
{
    Task<PaymentIntent> GetPaymentIntentByIdAsync(int paymentIntentId);
    Task<PaymentIntent> GetPaymentIntentByStripePaymentIntentIdAsync(string stripePaymentIntentId);
    Task<PaymentIntent> CreatePaymentIntentAsync(PaymentIntent paymentIntent);
    Task UpdatePaymentIntentAsync(PaymentIntent paymentIntent);
    Task DeletePaymentIntentAsync(PaymentIntent paymentIntent);
}