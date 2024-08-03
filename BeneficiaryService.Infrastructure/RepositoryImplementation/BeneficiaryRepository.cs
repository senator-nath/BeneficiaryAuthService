using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Domain.Entity;
using BeneficiaryService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Persistence.RepositoryImplementation
{
    public class BeneficiaryRepository : GenericRepository<Beneficiary>, IBeneficiaryRepository
    {
        private readonly BeneficiaryDbContext _dbContext;
        public BeneficiaryRepository(BeneficiaryDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<(IEnumerable<Beneficiary> Items, int TotalCount)> GetByAccountNumberAsync(string accountNumber, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Beneficiary>().Where(b => b.BenefactorAccountNumber == accountNumber);
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
