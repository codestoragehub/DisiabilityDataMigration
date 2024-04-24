using Microsoft.Extensions.Caching.Memory;

namespace DisabilityInPortal.Infrastructure.Cache
{
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; } = new(new MemoryCacheOptions { SizeLimit = 1024 });
    }
}