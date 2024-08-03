using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Dtos.Response
{
    public class BeneficiaryResponseDetailsDto
    {
        public string Message { get; set; }
        public BeneficiaryResponseDto ResponseDetails { get; set; }
        public bool IsSuccess { get; set; }
    }
}
