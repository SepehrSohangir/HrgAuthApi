using AutoMapper;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    private readonly ITokenDescriptorBuilder _tokenDescriptorBuilder;
    private readonly ITokenDescriptorFactory _tokenDescriptorFactory;

    public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration,
        ITokenDescriptorBuilder tokenDescriptorBuilder, ITokenDescriptorFactory tokenDescriptorFactory)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
        _tokenDescriptorBuilder = tokenDescriptorBuilder;
        _tokenDescriptorFactory = tokenDescriptorFactory;
    }
    public string GenerateToken(UsersDto inputUser)
    {
        try
        {
            var userPassword = _repository.GetUserPassword(inputUser.UserId, inputUser.CompanyID);
            if (!ValidateUserPassword(inputUser.Password, userPassword))
                return string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);
            var tokenDescriptor = _tokenDescriptorBuilder.WithSubject
                (
                    _tokenDescriptorFactory.CreateClaims(inputUser.UserId, inputUser.CompanyID)
                )
                .WithIssuer(_configuration["JWT:Issuer"])
                .WithAudience(_configuration["JWT:Audience"])
                .WithIssuedAt(DateTime.UtcNow)
                .WithExpirationTime(DateTime.UtcNow.AddMinutes(30))
                .WithSigningCredentials(new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature))
                .Build();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        catch(Exception ex)
        {
            return string.Empty;
        }
    }
    public bool ValidateUserPassword(string inputPassword, string realPassword)
    {
        // Ensure that neither the inputPassword nor the realPassword is null
        if (inputPassword is null || realPassword is null)
        {
            return false;
        }

        try
        {
            // Use BCrypt.Verify to check the inputPassword against the hashed realPassword
            return string.Equals(realPassword, inputPassword);
        }
        catch (BCrypt.Net.SaltParseException)
        {
            // Handle the SaltParseException, likely due to invalid salt version
            return false;
        }
    }

}
