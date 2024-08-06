using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.ExternalServiceContracts
{
    public interface IJwtTokenValidation
    {
        Task<bool> ValidateJwtTokenAsync(string token);
    }
}
