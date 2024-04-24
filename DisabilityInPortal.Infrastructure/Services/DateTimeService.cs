using System;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

namespace DisabilityInPortal.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}