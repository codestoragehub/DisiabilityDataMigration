using System.Threading;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Payments.PaymentIntent;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IPaymentProviderService
{
    Task<CreatePaymentIntentResponse> CreatePaymentIntentAsync(
        CreatePaymentIntentRequest request,
        CancellationToken token);
}