using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Domain.Identity;

public class ApplicationRole : IdentityRole
{
    public ApplicationRole()
    {
    }

    public ApplicationRole(string roleName) : base(roleName)
    {
    }

    public ApplicationRole(string roleName, string description) : base(roleName)
    {
        Description = description;
    }

    public string Description { get; set; }

    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}