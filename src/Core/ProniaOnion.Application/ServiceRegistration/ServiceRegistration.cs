using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ProniaOnion104.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            return service;
        }
    }
}