using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.AuditLogs;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Audit> _repositoryAsync;

        public LogRepository(IRepositoryAsync<Audit> repositoryAsync, IMapper mapper, IDateTimeService dateTimeService)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }

        public async Task AddLogAsync(string action, string userId)
        {
            var audit = new Audit
            {
                Type = action,
                UserId = userId,
                DateTimeOffset = _dateTimeService.UtcNow
            };
            await _repositoryAsync.AddAsync(audit);
        }

        public async Task<List<ActivityLogEntity>> GetLogsAsync(string userId)
        {
            var logs = await _repositoryAsync.Entities
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.AuditId)
                .Take(100)
                .ToListAsync();

            var mappedLogs = _mapper.Map<List<ActivityLogEntity>>(logs);
            return mappedLogs;
        }
    }
}