using HrgAuthApi.Dto;
using HrgAuthApi.Models.UsersDbModels;

namespace HrgAuthApi.Interfaces;

public interface IUserRepository
{
    Users GetUserInfo(int userId, int companyId);
    string GetUserGroupPermissionCode(int groupCode);
    string GetUserPassword(int userId, int companyId);
    bool DoesUserExist(UsersDto user);
}
