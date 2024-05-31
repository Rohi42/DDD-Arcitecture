using AutoMapper;
using CGC.API.DTO;
using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Base;
using CGC.Domain.Models.ValueObjects;
namespace CGC.API.Mapper
{
    public class WorkerItemProfile : Profile
    {
        public WorkerItemProfile()
        {
            CreateMap<WorkItemDto, Fields>().ReverseMap();
            CreateMap<WorkItemDto, WorkItem>().ReverseMap();


            CreateMap<WorkItemDto, User>().ReverseMap();
            
            



        }

    }
}
