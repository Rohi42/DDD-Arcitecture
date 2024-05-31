using AzureDevops.DataAccess;
using AzureDevops.Domain.Aggregates.WIT;
using AzureDevops.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevops.Data.Repository
{
    public class WorkItemRepository : Repository<WorkItem>
    {
        public WorkItemRepository(WorkItemContext context) : base(context)
        {
        }
    }
}
