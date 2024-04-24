using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface IBlobNameProvider
    {
        string Get(Document document);
        string GetSupplierProfileDocument(SupplierProfileDocument document);
    }
}