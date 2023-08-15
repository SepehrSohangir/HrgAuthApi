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

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("GenerateToken", Name = "GenerateToken")]
        public IActionResult GenerateToken(UsersDto user)
        {
            var result = _userService.ValidateUserInfo(user);
            if (!result.IsValid)
            {
                return BadRequest(
                        Results.ValidationProblem(
                            result.ToDictionary(),
                            title: "تعدادی از اطلاعات وارد شده صحیح نمیباشند.",
                            statusCode: StatusCodes.Status400BadRequest
                        )
                    );

            }
            var token = _userService.GenerateToken(user);
            return Ok(token);
        }
    }
}
