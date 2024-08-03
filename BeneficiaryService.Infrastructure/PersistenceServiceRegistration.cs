using BeneficiaryService.Infrastructure.Data;
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
            services.AddDbContext<BeneficiaryDbContext>(Options => Options.UseSqlServer(config.GetConnectionString("defaultConnection")));
            return services;
        }
    }
}
