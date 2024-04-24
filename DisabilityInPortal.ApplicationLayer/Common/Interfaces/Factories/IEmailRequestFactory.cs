using DisabilityInPortal.Domain.Models.Email;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Factories;

public interface IEmailRequestFactory
{
    EmailRequest CreateAccountConfirmationEmail(string to, string verificationUri);
}