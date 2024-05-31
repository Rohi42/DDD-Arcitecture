using CGC.API.DTO;
using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Aggregates.WIT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CGC.API.Services
{
    public interface IWorkItemService
    {
        Task<WorkItem> GetById(int id);
        Task<IEnumerable<WorkItemDto>> GetAll();
        Task<IEnumerable<WorkItem>> GetBy(Expression<Func<WorkItem, bool>> expression);
        void Add(WorkItem workItem);

        void Delete(WorkItem workItem);


        Task<bool> DeleteSelected(int[] workItemdtos);
        Task<bool> DeleteById(int id);
        Task<bool> UpdateById(WorkItemDto workItemdto);
        Task<bool> CreateItem(WorkItemDto workItemdto);

    }
}
