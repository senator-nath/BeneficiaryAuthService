using BeneficiaryService.Application.Dtos.Request;
using BeneficiaryService.Application.Dtos.Response;
using BeneficiaryService.Application.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeneficiaryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryService _beneficiaryService;

        public BeneficiaryController(IBeneficiaryService beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateBeneficiaryAsync([FromBody] BeneficiaryRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }

            try
            {
                var response = await _beneficiaryService.CreateBeneficiaryAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBeneficiaryAsync(int id, [FromBody] UpdateBeneficiaryRequestdto request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }

            try
            {
                var response = await _beneficiaryService.UpdateBeneficiaryAsync(id, request);
                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Beneficiary not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBeneficiaryAsync(int id)
        {
            try
            {
                var response = await _beneficiaryService.DeleteBeneficiaryAsync(id);
                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Beneficiary not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetByAccountNumberAsync([FromQuery] string accountNumber, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return BadRequest("Account number cannot be null or empty");
            }

            try
            {
                var response = await _beneficiaryService.GetByAccountNumberAsync(accountNumber, pageNumber, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
