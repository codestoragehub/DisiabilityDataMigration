using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IRepositoryAsync<Invoice> _repository;

    public InvoiceRepository(IRepositoryAsync<Invoice> repository)
    {
        _repository = repository;
    }

    private IQueryable<Invoice> Invoices => _repository.Entities;

    public async Task<int> InsertAsync(Invoice invoice)
    {
        await _repository.AddAsync(invoice);
        
        return invoice.InvoiceId;
    }

    public Task DeleteAsync(Invoice invoice)
    {
        return _repository.DeleteAsync(invoice);
    }
}