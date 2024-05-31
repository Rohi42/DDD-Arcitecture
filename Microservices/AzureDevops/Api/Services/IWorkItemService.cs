using AzureDevops.Domain.Aggregates.WIT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureDevops.Api.Services
{
    public interface IWorkItemService
    {
        Task<WorkItem> GetById(int id);
        Task<IEnumerable<WorkItem>> GetAll();
        Task<IEnumerable<WorkItem>> GetBy(Expression<Func<WorkItem, bool>> expression);
        void Add(WorkItem workItem);

        void Delete(WorkItem workItem);

        void Update(WorkItem workItem);

    }
}
