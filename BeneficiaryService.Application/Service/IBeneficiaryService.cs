using BeneficiaryService.Application.Dtos.Request;
using BeneficiaryService.Application.Dtos.Response;
using BeneficiaryService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.ServiceContract
{
    public interface IBeneficiaryService
    {
        Task<BeneficiaryResponseDetailsDto> CreateBeneficiaryAsync(BeneficiaryRequestDto request);
        Task<BeneficiaryResponseDetailsDto> UpdateBeneficiaryAsync(int id, UpdateBeneficiaryRequestdto request);
        Task<BeneficiaryResponseDetailsDto> DeleteBeneficiaryAsync(int id);
        Task<PaginatedBeneficiaryResponseDto> GetByAccountNumberAsync(string accountNumber, int pageNumber, int pageSize);
    }
}
