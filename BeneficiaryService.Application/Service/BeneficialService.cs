using BeneficiaryService.Application.Dtos.Request;
using BeneficiaryService.Application.Dtos.Response;
using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Application.ServiceContract;
using BeneficiaryService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Service
{
    public class BeneficialService : IBeneficiaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeneficialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BeneficiaryResponseDetailsDto> CreateBeneficiaryAsync(BeneficiaryRequestDto request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var userBeneficiary = new Beneficiary
            {
                BeneficiaryName = request.BeneficiaryName,
                BenefactorName = request.BenefactorName,
                BenefactorAccountNumber = request.BenefactorAccountNumber,
                BankCode = request.BankCode,
                BankName = request.BankName,
                BenefactorNickname = request.BenefactorNickname,
                Narration = request.Narration,
                BeneficiaryAccountNumber = request.BeneficiaryAccountNumber
            };
            _unitOfWork.beneficiary.Add(userBeneficiary);
            await _unitOfWork.SaveAsync();
            var response = new BeneficiaryResponseDto
            {
                BeneficiaryName = request.BeneficiaryName,
                BeneficiaryAccountNumber = request.BeneficiaryAccountNumber,
                BenefactorName = request.BenefactorName,
                BenefactorAccountNumber = request.BenefactorAccountNumber,
                BankCode = request.BankCode,
                BankName = request.BankName,
                BenefactorNickname = request.BenefactorNickname,
                Narration = request.Narration,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };
            return new BeneficiaryResponseDetailsDto
            {
                Message = "Beneficiary created successfully",
                ResponseDetails = response,
                IsSuccess = true,
            };
        }

        public async Task<BeneficiaryResponseDetailsDto> DeleteBeneficiaryAsync(int id)
        {
            var userBeneficiary = await _unitOfWork.beneficiary.GetByIdAsync(b => b.Id == id);

            if (userBeneficiary == null)
            {
                throw new Exception("Beneficiary not found");
            }

            _unitOfWork.beneficiary.Delete(userBeneficiary);
            await _unitOfWork.SaveAsync();

            return new BeneficiaryResponseDetailsDto
            {
                Message = "Beneficiary deleted successfully",
                IsSuccess = true,
            };
        }




        public async Task<PaginatedBeneficiaryResponseDto> GetByAccountNumberAsync(string accountNumber, int pageNumber, int pageSize)
        {

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return new PaginatedBeneficiaryResponseDto
                {
                    Message = "Account number cannot be null or empty",
                    IsSuccess = false
                };
            }


            var beneficiariesCheck = await _unitOfWork.beneficiary.GetWhere(b => b.BenefactorAccountNumber == accountNumber);
            if (!beneficiariesCheck.Any())
            {
                return new PaginatedBeneficiaryResponseDto
                {
                    Message = "No beneficiaries found for the provided account number",
                    IsSuccess = false
                };
            }
            var (beneficiaries, totalCount) = await _unitOfWork.beneficiary.GetByAccountNumberAsync(accountNumber, pageNumber, pageSize);

            var responseDetails = beneficiaries.Select(b => new BeneficiaryResponseDto
            {
                Id = b.Id,
                BeneficiaryName = b.BeneficiaryName,
                BeneficiaryAccountNumber = b.BeneficiaryAccountNumber,
                BenefactorName = b.BenefactorName,
                BenefactorAccountNumber = b.BenefactorAccountNumber,
                BenefactorNickname = b.BenefactorNickname,
                BankName = b.BankName,
                BankCode = b.BankCode,
                Narration = b.Narration,
                DateCreated = b.DateCreated,
                DateUpdated = b.DateUpdated
            }).ToList();

            return new PaginatedBeneficiaryResponseDto
            {
                Message = "Beneficiaries retrieved successfully",
                ResponseDetails = responseDetails,
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                IsSuccess = true
            };
        }

        public async Task<BeneficiaryResponseDetailsDto> UpdateBeneficiaryAsync(int id, UpdateBeneficiaryRequestdto request)
        {
            var beneficiary = await _unitOfWork.beneficiary.GetByIdAsync(b => b.Id == id);

            if (beneficiary == null)
            {
                throw new KeyNotFoundException("Beneficiary not found");
            }

            beneficiary.BeneficiaryName = request.BeneficiaryName;
            beneficiary.BenefactorNickname = request.BenefactorNickname;
            beneficiary.BenefactorAccountNumber = request.BenefactorAccountNumber;
            beneficiary.DateUpdated = DateTime.UtcNow;

            _unitOfWork.beneficiary.Update(beneficiary);
            await _unitOfWork.SaveAsync();

            var response = new BeneficiaryResponseDto
            {
                BeneficiaryName = beneficiary.BeneficiaryName,
                BeneficiaryAccountNumber = beneficiary.BeneficiaryAccountNumber,
                BenefactorName = beneficiary.BenefactorName,
                BenefactorAccountNumber = beneficiary.BenefactorAccountNumber,
                BankCode = beneficiary.BankCode,
                BankName = beneficiary.BankName,
                BenefactorNickname = beneficiary.BenefactorNickname,
                Narration = beneficiary.Narration,
                DateCreated = beneficiary.DateCreated,
                DateUpdated = beneficiary.DateUpdated
            };

            return new BeneficiaryResponseDetailsDto
            {
                Message = "Beneficiary updated successfully",
                ResponseDetails = response,
                IsSuccess = true
            };
        }


    }
}
