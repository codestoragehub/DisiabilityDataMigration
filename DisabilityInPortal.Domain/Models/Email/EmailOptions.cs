namespace DisabilityInPortal.Domain.Models.Email;

public class EmailOptions
{
    public string[] Bccs { get; set; }
    public string AccountConfirmationSubject { get; set; }
    public string AccountConfirmationBody { get; set; }
    public string ResetPasswordSubject { get; set; }
    public string ResetPasswordBody { get; set; }
}