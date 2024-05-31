using CGC.DataAccess;
using   CGC.Domain.Aggregates.WIT;
using CGC.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGC.Data.Repository
{
    public class WorkItemRepository : Repository<WorkItem>
    {
        public WorkItemRepository(WorkItemContext context) : base(context)
        {
        }
    }
}
