using HrgAuthApi.Context;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models;
using System.Text;

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
        var userInfo = (from us in _context.Users
                        join ug in _context.UserGroups on us.GroupCode equals ug.GroupCode
                        where us.UserId == userId && us.CompanyID == companyId
                        select new Users
                        {
                            UserId = us.UserId,
                            FirstName = us.FirstName,
                            Surname = us.Surname,
                            IdNumber = us.IdNumber,
                            Organ = us.Organ,
                            Post = us.Post,
                            UserName = us.UserName,
                            GroupCode = us.GroupCode,
                            Password = us.Password,
                            PukCode = us.PukCode,
                            Picture = us.Picture,
                            CompanyID = us.CompanyID,
                            PID = us.PID,
                            startPageMode = us.startPageMode,
                            UserWord = us.UserWord,
                            DisableUser = us.DisableUser,
                            ID = us.ID,
                            usrPasswordSalt = us.usrPasswordSalt,
                            UserMustChangePassword = us.UserMustChangePassword,
                            LastPasswordChange = us.LastPasswordChange,
                            PTAC = us.PTAC,
                            Phonenumber = us.Phonenumber,
                            LastLoginDate = us.LastLoginDate,
                            UserGroup = ug  // Populate the UserGroup navigation property
                        }).FirstOrDefault();
        ArgumentNullException.ThrowIfNull(userInfo, nameof(userInfo));
        return userInfo;
    }
    public string GetUserPassword(int userId, int companyId)
    {
        var userPassword = _context.Users
            ?.FirstOrDefault(e => e.UserId == userId && e.CompanyID == companyId)
            ?.Password;
        ArgumentNullException.ThrowIfNull(userPassword, nameof(userPassword));
        return Convert.ToBase64String(userPassword);
    }
    public bool DoesUserExist(UsersDto user)
    {
        var userExists = _context.Users
            .Where(e => e.UserId == user.UserId && e.CompanyID == user.CompanyID)
            .AsEnumerable()
            .Any(e => Convert.ToBase64String(e.Password) == user.Password);
        return userExists;
    }

}
