using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface ISearchService
    {
       List<SearchQueryResult> SearchSupplierByParameterAsync(SearchRequest searchRequest);
    }
}
