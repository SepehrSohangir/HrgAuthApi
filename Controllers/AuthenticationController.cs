using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HrgAuthApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidationHandler _validationHandler;

        public AuthenticationController(
            IUserService userService,
            IValidationHandler validationHandler)
        {
            _userService = userService;
            this._validationHandler = validationHandler;
        }
        [HttpPost("GenerateToken", Name = "GenerateToken")]
        public IActionResult GenerateToken(UsersDto user)
        {
            var validationResult = _userService.ValidateUserInfo(user);
            var isValid = _validationHandler.ValidateJsonObject(validationResult, out FailedResponseDto badRequestObject);
            if (!isValid)
            {
                return BadRequest(badRequestObject);
            }
            var result = _validationHandler.WrapSuccessfulResponse(_userService.GenerateToken(user));
            return Ok(result);
        }
    }
}
