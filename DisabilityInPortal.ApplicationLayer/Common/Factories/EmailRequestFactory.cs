using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Factories;
using DisabilityInPortal.Domain.Models.Email;
using Microsoft.Extensions.Options;

namespace DisabilityInPortal.ApplicationLayer.Common.Factories
{
    public class EmailRequestFactory : IEmailRequestFactory
    {
        private readonly EmailOptions _options;

        public EmailRequestFactory(IOptions<EmailOptions> options)
        {
            _options = options.Value;
        }

        public EmailRequest CreateAccountConfirmationEmail(string to, string verificationUri)
        {
            return new EmailRequest
            {
                To = to,
                Subject = _options.AccountConfirmationSubject,
                Body = _options.AccountConfirmationBody.Replace("{uri}", verificationUri),
                Bccs = _options.Bccs
            };
        }
    }
}

