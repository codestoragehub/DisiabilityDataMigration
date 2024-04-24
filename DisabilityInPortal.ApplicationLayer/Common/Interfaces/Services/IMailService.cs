using System.Threading.Tasks;
using DisabilityInPortal.Domain.Models.Email;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IMailService
{
    Task SendEmailAsync(EmailRequest request);
}