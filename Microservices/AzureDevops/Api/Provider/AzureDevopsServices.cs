using AzureDevops.Api.Services;
using AzureDevops.Data.Repository;
using AzureDevops.Domain.Aggregates.WIT;
using AzureDevops.Domain.Base;
using AzureDevops.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevops.Api.Provider
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
