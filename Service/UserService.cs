using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HrgAuthApi.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ITokenDescriptorBuilder _tokenDescriptorBuilder;
    private readonly ITokenDescriptorFactory _tokenDescriptorFactory;
    private readonly IValidator<UsersDto> _userValidator;

    public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration,
        ITokenDescriptorBuilder tokenDescriptorBuilder, ITokenDescriptorFactory tokenDescriptorFactory,
        IValidator<UsersDto> userValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
        _tokenDescriptorBuilder = tokenDescriptorBuilder;
        _tokenDescriptorFactory = tokenDescriptorFactory;
        this._userValidator = userValidator;
    }
    public TokenDto GenerateToken(UsersDto inputUser)
    {
        var userPassword = _repository.GetUserPassword(inputUser.UserId, inputUser.CompanyID);

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
        var tokenDto = new TokenDto
        {
            ExpiresIn = tokenDescriptor.Expires.Value,
            GeneratedAt = tokenDescriptor.IssuedAt.Value,
            Token = tokenHandler.WriteToken(token)
        };
        return tokenDto;
    }
    public ValidationResult ValidateUserInfo(UsersDto user)
    {
        return _userValidator.Validate(user);
    }

}
