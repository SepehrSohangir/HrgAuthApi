using HrgAuthApi.Dto;
using Microsoft.AspNetCore.Identity;

namespace HrgAuthApi.Interfaces;

public interface IUserService
{
    string GenerateToken(UsersDto user);
}
