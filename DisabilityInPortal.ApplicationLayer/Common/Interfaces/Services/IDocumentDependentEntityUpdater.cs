using DisabilityInPortal.Domain.Entities;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Services
{
    public interface IDocumentDependentEntityUpdater
    {
        Task UpdateDependentEntitiesAsync(Document document);
    }
}