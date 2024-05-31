using AzureDevops.Api.Services;
using AzureDevops.Data.Repository;
using AzureDevops.Domain.Aggregates.WIT;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDevops.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        IWorkItemService _workItemService;
        public WorkItemController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> GetAsync()
        {
            //var azureService = _workItemService;
            var items = await _workItemService.GetAll();
            return items;
        }

        [HttpGet("{id}")]
        public async Task<WorkItem> GetByIdAsync(String id)
        {
            //var azureService = new AzureWorkItemRepository();
            var items = await _workItemService.GetById(int.Parse(id));
            return items;
        }
    }
}