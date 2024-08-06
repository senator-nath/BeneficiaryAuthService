using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Persistence.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BeneficiaryDbContext _dbContext;

        public IBeneficiaryRepository beneficiary { get; }
        public UnitOfWork(BeneficiaryDbContext dbContext)
        {
            _dbContext = dbContext;

            beneficiary = new BeneficiaryRepository(dbContext);
        }
        public void Dispose()
        {
            _dbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                var save = await _dbContext.SaveChangesAsync();
                return save;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
