using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Domain.Identity;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}