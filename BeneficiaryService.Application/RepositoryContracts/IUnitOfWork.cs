using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IBeneficiaryRepository beneficiary { get; }
        Task<int> SaveAsync();
    }
}
