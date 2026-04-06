using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using System.Reflection;

namespace Plan.HospitalGaragoa.Application.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // register AutoMapper profiles in this assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // register MediatR handlers in this assembly
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
