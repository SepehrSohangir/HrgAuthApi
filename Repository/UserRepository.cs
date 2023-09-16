using HrgAuthApi.Context;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models.UsersDbModels;
using System.Text;

namespace HrgAuthApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _usersDbContext;
    private readonly PublicDbContext _publicDbContext;

    public UserRepository(UsersDbContext salesDbContext, PublicDbContext publicDbContext)
    {
        this._usersDbContext = salesDbContext;
        this._publicDbContext = publicDbContext;
    }
    public string GetUserGroupPermissionCode(int groupCode)
    {
        return _usersDbContext.UserGroups
            .Where(e => e.GroupCode == groupCode)
            .Select(e => e.PermissionCode)
            .FirstOrDefault() ?? string.Empty;
    }

    public Users GetUserInfo(int userId, int companyId)
    {
        var userInfo = (from us in _usersDbContext.Users
                        join ug in _usersDbContext.UserGroups on us.GroupCode equals ug.GroupCode
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
                            LastPasswordChangeDate = us.LastPasswordChangeDate,
                            PTAC = us.PTAC,
                            Phonenumber = us.Phonenumber,
                            LastLoginDate = us.LastLoginDate,
                            UserGroup = ug  // Populate the UserGroup navigation property
                        }).FirstOrDefault();
        ArgumentNullException.ThrowIfNull(userInfo, nameof(userInfo));
        return userInfo;
    }
    public bool MoadianSubSystemExists(int moadianSubsystemId)
    {
        return _publicDbContext.TblMoadianSubSystems_H.Any(e => e.Id == moadianSubsystemId);
    }
    public string GetUserPassword(int userId, int companyId)
    {
        var userPassword = _usersDbContext.Users
            ?.FirstOrDefault(e => e.UserId == userId && e.CompanyID == companyId)
            ?.Password;
        ArgumentNullException.ThrowIfNull(userPassword, nameof(userPassword));
        return Convert.ToBase64String(userPassword);
    }
    public bool DoesUserExist(UsersDto user)
    {
        var userExists = _usersDbContext.Users
            .Where(e => e.UserId == user.UserId && e.CompanyID == user.CompanyID)
            .AsEnumerable()
            .Any(e => Convert.ToBase64String(e.Password) == user.Password);
        return userExists;
    }

}
