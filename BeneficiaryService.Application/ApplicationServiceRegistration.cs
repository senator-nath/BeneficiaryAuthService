using BeneficiaryService.Application.Service;
using BeneficiaryService.Application.ServiceContract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IBeneficiaryService, BeneficialService>();
            return services;
        }
    }
}
