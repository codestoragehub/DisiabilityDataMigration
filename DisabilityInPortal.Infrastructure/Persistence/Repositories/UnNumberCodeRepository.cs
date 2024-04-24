using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class UnNumberCodeRepository : IUnNumberCodeRepository
{
    private readonly IRepositoryAsync<UnNumberCode> _repository;

    public UnNumberCodeRepository(IRepositoryAsync<UnNumberCode> repository)
    {
        _repository = repository;
    }

    public Task<List<UnNumberCode>> SearchAsync(string searchTerm)
    {
        return _repository.Entities
            .Where(p =>
                EF.Functions.Like(p.Code, $"%{searchTerm}%") ||
                EF.Functions.Like(p.Description, $"%{searchTerm}%"))
            .OrderByDescending(c => EF.Functions.Like(c.Description, $"{searchTerm}%"))
            .ThenBy(c => c.Description)
            .Take(Constants.FetchSize)
            .ToListAsync();
    }

    public Task<List<UnNumberCode>> GetListAsync(IEnumerable<string> unNumberCodes)
    {
        return _repository.Entities
            .OrderBy(c => c.Description)
            .Where(c => unNumberCodes.Contains(c.Code))
            .ToListAsync();
    }
}