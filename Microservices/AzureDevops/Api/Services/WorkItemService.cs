using AzureDevops.Data.Repository;
using AzureDevops.Domain.Aggregates.WIT;
using AzureDevops.Domain.Base;
using AzureDevops.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureDevops.Api.Services
{
    public class WorkItemService : IWorkItemService
    {
        IRepository<WorkItem> _witRepo;
        IAzureDomainService _azureDomainService;
        public WorkItemService(IRepository<WorkItem> witRepo, IAzureDomainService azureDomainService)
        {
            _witRepo = witRepo;
            _azureDomainService = azureDomainService;
        }
        public void Add(WorkItem workItem)
        {
            _witRepo.Add(workItem);
        }

        public void Delete(WorkItem workItem)
        {

        }

        public Task<IEnumerable<WorkItem>> GetAll()
        {
            return _azureDomainService.GetAll();
        }

        public Task<IEnumerable<WorkItem>> GetBy(Expression<Func<WorkItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<WorkItem> GetById(int id)
        {
            return _azureDomainService.GetById(id.ToString());
        }

        public void Update(WorkItem workItem)
        {

        }
    }
}
