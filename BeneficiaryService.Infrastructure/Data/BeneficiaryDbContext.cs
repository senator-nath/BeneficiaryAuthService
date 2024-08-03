using BeneficiaryService.Domain.Entity;
using BeneficiaryService.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Infrastructure.Data
{
    public class BeneficiaryDbContext : DbContext
    {
        public BeneficiaryDbContext(DbContextOptions<BeneficiaryDbContext> options) : base(options)
        {

        }
        public DbSet<Beneficiary> Beneficiary { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BeneficiaryConfiguration());
        }
    }
}
