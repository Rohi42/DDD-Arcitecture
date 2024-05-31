using AutoMapper;
using CGC.API.DTO;
using CGC.API.Services;
using CGC.Domain.Aggregates.WIT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace CGC.API.Controller
{

    [Route("api/[controller]")]
        [ApiController]
        public class BugReviewController : ControllerBase
        {
            private readonly IWorkItemService _workItemService;
            private readonly IMapper _mapper;
            private readonly ILogger<BugReviewController> _logger;

        public BugReviewController(IWorkItemService workItemService, IMapper mapper, ILogger<BugReviewController> logger)
            {
                _workItemService = workItemService;
                _mapper = mapper;   
                _logger = logger;
            }

            [HttpGet]
            [ProducesResponseType(typeof(IEnumerable<WorkItemDto>), (int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
            [Authorize]
            [Route("/GetAll")]
            public async Task<ActionResult<IEnumerable<WorkItemDto>>> GetAsync()
            {
            try
            {

                var items = await _workItemService.GetAll();
                if (items != null)
                {
                    
                    return Ok(items);
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return this.Problem();
            }

            }

            [HttpGet]
            [ProducesResponseType(typeof(WorkItemDto), (int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
           // [Authorize]
        [Route("/GetByID/{id}")]
            public async Task<ActionResult<WorkItemDto>> GetByIdAsync(string id)
            {
            try
            {

                var items = await _workItemService.GetById(int.Parse(id));
                var itemWithPriority = _mapper.Map(items, _mapper.Map<WorkItemDto>(items.Fields));
                var ItemsWithAssignTo = _mapper.Map(items.Fields.SystemAssignedTo, itemWithPriority);
                
                return Ok(ItemsWithAssignTo);
            }
            catch (Exception ex)
            {
                return this.Problem();
            }
            
            }

            [HttpDelete]
            [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
            //[Authorize(Roles ="admin")]
            [Route("/DeleteByID/{id}")]
            public async Task<ActionResult<bool>> DeleteByIDAsync(string id)
            {
            
              var items = await _workItemService.DeleteById(int.Parse(id));

            if (items)
            {
                
                return Ok();
            }
            else
                return BadRequest();
            }

            [HttpPatch]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
           // [Authorize(Roles = "admin")]
            [Route("/Update")]
            public async Task<ActionResult> UpdateByIDAsync(WorkItemDto workItem)
            {
            try
            {

                var items = await _workItemService.UpdateById(workItem);
                if (items)
                {
                    
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex) { 
                return this.Problem();
            }

            }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[Authorize(Roles = "admin")]
        [Route("/DeleteSelected")]

        public async Task<ActionResult> DeleteSelectedAsync(int[] workItemdtos)
        {
            try {

                var items = await _workItemService.DeleteSelected(workItemdtos);

                if (items)
                {
                    
                     return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return this.Problem();
            }
            }
        

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[Authorize(Roles = "admin")]
        [Route("/CreateItem")]
        public async Task<ActionResult> CreateItemAsync(WorkItemDto workItemdto)
        {
            try
            {
                var items = await _workItemService.CreateItem(workItemdto);

                if (items)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return this.Problem();
            }
            }


        }
    }

