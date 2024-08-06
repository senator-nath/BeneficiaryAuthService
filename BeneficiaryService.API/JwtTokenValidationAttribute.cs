using BeneficiaryService.Application.ExternalServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeneficiaryService.API
{
    public class JwtTokenValidationAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IJwtTokenValidation _jwtTokenValidation;

        public JwtTokenValidationAttribute(IJwtTokenValidation jwtTokenValidation)
        {
            _jwtTokenValidation = jwtTokenValidation;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token) || !await _jwtTokenValidation.ValidateJwtTokenAsync(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
