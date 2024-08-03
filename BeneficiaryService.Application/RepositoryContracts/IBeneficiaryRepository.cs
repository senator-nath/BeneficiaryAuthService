using BeneficiaryService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.RepositoryContracts
{
    public interface IBeneficiaryRepository : IGenericRepository<Beneficiary>
    {
        Task<(IEnumerable<Beneficiary> Items, int TotalCount)> GetByAccountNumberAsync(string accountNumber, int pageNumber, int pageSize);
    }
}
