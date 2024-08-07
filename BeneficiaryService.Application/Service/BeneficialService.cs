using BeneficiaryService.Application.Dtos.Request;
using BeneficiaryService.Application.Dtos.Response;
using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Application.ServiceContract;
using BeneficiaryService.Application.Validator;
using BeneficiaryService.Domain.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
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
        private readonly BeneficiaryRequestValidator _validations;
        private readonly ILogger<BeneficialService> _logger;

        public BeneficialService(IUnitOfWork unitOfWork, BeneficiaryRequestValidator validations, ILogger<BeneficialService> logger)
        {
            _unitOfWork = unitOfWork;
            _validations = validations;
            _logger = logger;
        }
        public async Task<BeneficiaryResponseDetailsDto> CreateBeneficiaryAsync(BeneficiaryRequestDto request)
        {
            _logger.LogInformation("Starting CreateBeneficiaryAsync ");
            var validationResult = await _validations.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation Failed:{errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }
            if (request is null)
            {
                _logger.LogWarning("CreateBeneficiaryAsync: request is null");
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

            _logger.LogInformation("Beneficiary created successfully");
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
            _logger.LogInformation("Starting DeleteBeneficiaryAsync");
            var userBeneficiary = await _unitOfWork.beneficiary.GetByIdAsync(b => b.Id == id);

            if (userBeneficiary == null)
            {
                _logger.LogWarning("DeleteBeneficiaryAsync:User with Id: {id} not found", id);
                throw new Exception("Beneficiary not found");
            }

            _unitOfWork.beneficiary.Delete(userBeneficiary);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Beneficiary updated successfully for ID: {Id}", id);
            return new BeneficiaryResponseDetailsDto
            {
                Message = "Beneficiary deleted successfully",
                IsSuccess = true,
            };
        }




        public async Task<PaginatedBeneficiaryResponseDto> GetByAccountNumberAsync(string accountNumber, int pageNumber, int pageSize)
        {
            _logger.LogInformation("Starting GetByAccountNumberAsync for Account Number: {AccountNumber}", accountNumber);

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                _logger.LogWarning("GetByAccountNumberAsync: Account number is null or empty");
                return new PaginatedBeneficiaryResponseDto
                {
                    Message = "Account number cannot be null or empty",
                    IsSuccess = false
                };
            }


            var beneficiariesCheck = await _unitOfWork.beneficiary.GetWhere(b => b.BenefactorAccountNumber == accountNumber);
            if (!beneficiariesCheck.Any())
            {
                _logger.LogWarning("GetByAccountNumberAsync: No beneficiaries found for Account Number: {AccountNumber}", accountNumber);
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
            _logger.LogInformation("Beneficiaries retrieved successfully for Account Number: {AccountNumber}", accountNumber);
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
