using System;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface IDateTimeService
    {
        DateTimeOffset UtcNow { get; }
    }
}