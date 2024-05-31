using AzureDevops.Domain.Aggregates.WIT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Base
{
    public interface IAsyncProvider
    {
        public Task<IEnumerable<WorkItem>> GetAll();

        Task<WorkItem> GetById(int id);

        void Add(WorkItem entity);

        void Delete(WorkItem entity);

        void Update(WorkItem entity);

    }
}
