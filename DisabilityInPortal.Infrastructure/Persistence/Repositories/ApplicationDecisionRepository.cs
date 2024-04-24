using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ApplicationDecisionRepository : IApplicationDecisionRepository
{
    private readonly IRepositoryAsync<ApplicationDecision> _repository;

    public ApplicationDecisionRepository(IRepositoryAsync<ApplicationDecision> repository)
    {
        _repository = repository;
    }

    public Task<ApplicationDecision> GetByApplicationIdAsync(int applicationId)
    {
        return _repository.Entities
            .Include(d => d.Application).ThenInclude(a => a.PaymentDetail)
            .Include(d => d.Application).ThenInclude(a => a.Invoice).ThenInclude(i => i.InvoiceItems)
            .Include(d => d.Application).ThenInclude(a => a.Invoice).ThenInclude(i => i.PaymentIntents)
            .Include(d => d.Application).ThenInclude(a => a.Invoice).ThenInclude(i => i.Payment)
            .FirstOrDefaultAsync(f => f.ApplicationId == applicationId);
    }

    public Task<ApplicationDecision> CreateAsync(ApplicationDecision applicationDecision)
    {
        return _repository.AddAsync(applicationDecision);
    }

    public Task UpdateAsync(ApplicationDecision applicationDecision)
    {
        return _repository.UpdateAsync(applicationDecision);
    }
}