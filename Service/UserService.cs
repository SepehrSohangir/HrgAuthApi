using AutoMapper;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HrgAuthApi.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
    }
    public string GenerateToken(UsersDto userInput)
    {
        try
        {
            var userOutput = _repository.GetUserInfo(userInput.UserId, userInput.CompanyID);
            if (ValidateUserInputData(userInput, userOutput))
                return string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userOutput.UserName),
                    new Claim(ClaimTypes.Surname, userOutput.Surname),
                    new Claim(ClaimTypes.)
                    new Claim("GroupCode", Convert.ToString(userOutput.GroupCode)),
                    new Claim(ClaimTypes.)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
        }
        catch(Exception ex)
        {

        }
    }
    private bool ValidateUserInputData(UsersDto userInput, Users userOutput)
    {
        return userInput is not null &&
            BCrypt.Net.BCrypt.Verify(Convert.ToBase64String(userInput.Password), Convert.ToBase64String(userOutput.Password ?? Array.Empty<byte>()));
    }
}
