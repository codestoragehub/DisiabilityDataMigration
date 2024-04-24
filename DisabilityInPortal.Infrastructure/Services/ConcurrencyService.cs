using System.Collections.Concurrent;
using System.Threading;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

namespace DisabilityInPortal.Infrastructure.Services;

public class ConcurrencyService : IConcurrencyService
{
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> Semaphores = new();
    private readonly ICurrentUserService _currentUserService;

    public ConcurrencyService(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public SemaphoreSlim SemaphorePerUser(string contextKey, int initialCount = 1, int maxCount = 1)
    {
        var key = $"{_currentUserService.UserId}_{contextKey}";
        return Semaphores.GetOrAdd(key, new SemaphoreSlim(initialCount, maxCount));
    }
}