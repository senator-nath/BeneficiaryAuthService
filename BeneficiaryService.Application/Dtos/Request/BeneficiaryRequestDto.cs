using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Dtos.Request
{
    public class BeneficiaryRequestDto
    {

        public string BeneficiaryName { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BenefactorName { get; set; }
        public string BenefactorAccountNumber { get; set; }
        public string BenefactorNickname { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string Narration { get; set; }

    }
}
