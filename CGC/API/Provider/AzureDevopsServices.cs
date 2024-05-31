using CGC.API.Services;
using CGC.Data.Repository;
using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Base;
using CGC.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CGC.API.Provider
{
    public static class AzureDevopsServices
    {
        public static IServiceCollection AddAzureDevopsServices(this IServiceCollection services)
        {
            services.AddTransient<IWorkItemService, WorkItemService>();
            services.AddTransient<IRepository<WorkItem>, WorkItemRepository>();
            services.AddTransient<IAzureDomainService, AzureDomainService>();
            return services;
        }
    }
}
