using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IInvoiceRepository
{
    Task<int> InsertAsync(Invoice invoice);
    Task DeleteAsync(Invoice invoice);
}