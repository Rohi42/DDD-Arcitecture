using CGC.API.DTO;
using CGC.Data.Repository;
using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Base;
using CGC.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CGC.API.Services
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

        public Task<IEnumerable<WorkItemDto>> GetAll()
        {
            return _azureDomainService.GetAll();
        }

        public Task<IEnumerable<WorkItem>> GetBy(Expression<Func<WorkItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkItem> GetById(int id)
        {

            return await _azureDomainService.GetById(id.ToString());
        }

        public Task<bool> DeleteById(int id)
        {
            return _azureDomainService.DeleteById(id.ToString());
        }
        public async Task<bool> UpdateById(WorkItemDto workItemdto)
        {
            return await _azureDomainService.UpdateById(workItemdto);
        }
        public async Task<bool> DeleteSelected(int[] workItemdtos)
        {
            return await _azureDomainService.DeleteSelected(workItemdtos);
        }
        public async Task<bool> CreateItem(WorkItemDto workItemdto)
        {
            return await _azureDomainService.CreateItem(workItemdto);
        }
    }
}
