using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.AuditLogs
{
    public interface ILogRepository
    {
        Task<List<ActivityLogEntity>> GetLogsAsync(string UserId);
        Task AddLogAsync(string action, string UserId);
    }
}