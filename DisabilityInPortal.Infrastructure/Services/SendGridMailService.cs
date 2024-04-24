using System;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Models.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DisabilityInPortal.Infrastructure.Services;

public class SendGridMailService : IMailService
{
    private readonly ILogger<SendGridMailService> _logger;
    private readonly SendGridMailSenderOptions _options;

    public SendGridMailService(
        IOptions<SendGridMailSenderOptions> options,
        ILogger<SendGridMailService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(EmailRequest request)
    {
        try
        {
            var response = await ExecuteAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }

    private async Task<Response> ExecuteAsync(EmailRequest request)
    {
        var client = new SendGridClient(_options.ApiKey);

        var msg = CreateMessage(request);

        msg.AddTo(new EmailAddress(request.To));

        return await client.SendEmailAsync(msg);
    }

    private SendGridMessage CreateMessage(EmailRequest request)
    {
        var message = new SendGridMessage
        {
            From = new EmailAddress(_options.SenderEmail, _options.SenderName),
            Subject = request.Subject,
            PlainTextContent = request.Body,
            HtmlContent = request.Body
        };

        AddBccsIfNeeded(request, message);

        return message;
    }

    private static void AddBccsIfNeeded(EmailRequest request, SendGridMessage msg)
    {
        var bccs = request?.Bccs?.Select(x => new EmailAddress(x))?.ToList();
        if (bccs?.Count > 0) msg.AddBccs(request.Bccs.Select(x => new EmailAddress(x)).ToList());
    }
}