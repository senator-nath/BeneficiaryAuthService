using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Dtos.Response
{
    public class PaginatedBeneficiaryResponseDto
    {
        public string Message { get; set; }
        public IEnumerable<BeneficiaryResponseDto> ResponseDetails { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool IsSuccess { get; set; }
    }
}
