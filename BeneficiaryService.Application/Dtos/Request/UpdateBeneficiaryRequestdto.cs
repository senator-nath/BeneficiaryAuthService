using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Dtos.Request
{
    public class UpdateBeneficiaryRequestdto
    {
        public string BeneficiaryName { get; set; }
        public string BenefactorNickname { get; set; }
        public string BenefactorAccountNumber { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
