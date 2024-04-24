using System.Threading;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Payments.PaymentIntent;
using Stripe;

namespace DisabilityInPortal.Infrastructure.Services;

public class PaymentProviderService : IPaymentProviderService
{
    public async Task<CreatePaymentIntentResponse> CreatePaymentIntentAsync(
        CreatePaymentIntentRequest request, 
        CancellationToken token)
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Amount = request.Amount,
            Currency = request.Currency,
            PaymentMethod = request.PaymentMethod,
            Customer = request.Customer,
            OffSession = true,
            Confirm = true
        }, cancellationToken: token);

        return new CreatePaymentIntentResponse
        {
            PaymentIntentId = paymentIntent.Id,
            PaymentIntentStatus = paymentIntent.Status
        };
    }
}