namespace DisabilityInPortal.Domain.Models.Email;

public class EmailRequest
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string[] Bccs { get; set; }
}