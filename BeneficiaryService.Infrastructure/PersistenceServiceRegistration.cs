using BeneficiaryService.Application.ExternalServiceContracts;
using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Infrastructure.Data;
using BeneficiaryService.Persistence.ExternalServiceImplementation;
using BeneficiaryService.Persistence.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
            services.AddScoped<IJwtTokenValidation, JwtTokenValidation>();
            services.AddHttpClient();

            services.AddDbContext<BeneficiaryDbContext>(Options => Options.UseSqlServer(config.GetConnectionString("defaultConnection")));
            return services;
        }
    }
}
