using System.Collections.Generic;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Helpers;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public string UserReference { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] ProfilePicture { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsUSABasedCompany { get; set; }
    public bool IsStartUpCompany { get; set; }
    public VeteranStatusType VeteranStatusType { get; set; }
    
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    public static string GenerateUserReference()
    {
        return ReferenceHelper.CreateReference(
            Constants.Constants.UserReferencePrefix,
            Constants.Constants.ReferenceLength);
    }

    public void SetUserReference(string userReference)
    {
        if (!string.IsNullOrWhiteSpace(UserReference))
            return;

        UserReference = userReference;
    }
}