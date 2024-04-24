using System.Collections.Generic;

namespace DisabilityInPortal.Infrastructure.Identity.Seeds
{
    public static class PermissionsGenerator
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }
    }
}