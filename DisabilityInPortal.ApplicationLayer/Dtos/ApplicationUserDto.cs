namespace DisabilityInPortal.ApplicationLayer.Features.Users.Queries.GetUserById;

public class ApplicationUserDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsUSABasedCompany { get; set; }
    public bool IsStartUpCompany { get; set; }
}