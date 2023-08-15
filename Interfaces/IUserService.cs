using FluentValidation.Results;
using HrgAuthApi.Dto;
using Microsoft.AspNetCore.Identity;

namespace HrgAuthApi.Interfaces;

public interface IUserService
{
    TokenDto GenerateToken(UsersDto inputUser);
    ValidationResult ValidateUserInfo(UsersDto user);
}
