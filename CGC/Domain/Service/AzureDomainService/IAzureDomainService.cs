using CGC.API.DTO;
using CGC.Domain.Aggregates.WIT;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGC.Domain.Service
{
    public interface IAzureDomainService
    {
        void init();
        Task<IEnumerable<WorkItemDto>> GetAll();
        Task<WorkItem> GetById(string id);
        Task<bool> DeleteById(string id);
        Task<bool> UpdateById(WorkItemDto workItemdto);
        Task<bool> DeleteSelected(int[] workItemdtos);

        Task<bool> CreateItem(WorkItemDto workItemdto);

    }
}