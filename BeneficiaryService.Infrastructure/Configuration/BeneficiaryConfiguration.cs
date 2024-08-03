using BeneficiaryService.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Infrastructure.Configuration
{
    public class BeneficiaryConfiguration
    : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.BeneficiaryName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BenefactorName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BenefactorAccountNumber).IsRequired().HasMaxLength(20);
            builder.Property(e => e.BenefactorNickname).HasMaxLength(50);
            builder.Property(e => e.BankName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.BankCode).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Narration).HasMaxLength(500);
            builder.Property(e => e.DateCreated).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DateUpdated).HasDefaultValueSql("GETDATE()");
        }
    }
}
