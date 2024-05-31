using AzureDevops.Domain.Aggregates.WIT;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Service
{
    public interface IAzureDomainService
    {
        void init();
        Task<IEnumerable<WorkItem>> GetAll();
        Task<WorkItem> GetById(string id);

    }
}