using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HrgAuthApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost(Name = "GenerateToken")]
        public IActionResult GenerateToken(UsersDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var token = _userService.GenerateToken(user);
            if (token is null)
                return BadRequest();
            return Ok(token);
        }
    }
}
