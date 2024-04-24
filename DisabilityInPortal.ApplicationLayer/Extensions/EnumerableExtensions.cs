using System.Collections.Generic;
using System.Linq;

namespace DisabilityInPortal.ApplicationLayer.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable switch
            {
                null => true,
                // If this is a list, use the Count property for efficiency.
                // The Count property is O(1) while IEnumerable.Count() is O(N).
                ICollection<T> collection => collection.Count < 1,
                _ => !enumerable.Any()
            };
        }
    }
}