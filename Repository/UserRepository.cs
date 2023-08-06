using HrgAuthApi.Context;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models;
namespace HrgAuthApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        this._context = context;
    }
    public string GetUserGroupPermissionCode(int groupCode)
    {
        return _context.UserGroups
            .Where(e => e.GroupCode == groupCode)
            .Select(e => e.PermissionCode)
            .FirstOrDefault() ?? string.Empty;
    }

    public Users GetUserInfo(int userId, int companyId)
    {
        var user = _context.Users
            .Where(e => e.UserId == userId && e.CompanyID == companyId)
            .FirstOrDefault() ?? new Users();
        return user;
    }
}
