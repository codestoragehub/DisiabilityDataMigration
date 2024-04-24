using System.Threading;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IConcurrencyService
{
    SemaphoreSlim SemaphorePerUser(string contextKey, int initialCount = 1, int maxCount = 1);
}