using BusinessProvider.Services;
using IBusiness.Interfaces;
using IRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using System;
//using Repository.Repositories;

namespace ServiceConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IExpenseService, ExpenseService>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            return services;
        }
    }
}
