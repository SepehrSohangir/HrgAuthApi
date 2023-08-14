using System.Security.Claims;

namespace HrgAuthApi.Interfaces
{
    public interface ITokenDescriptorFactory
    {
        ClaimsIdentity CreateClaims(int userId, int companyId);
        List<Claim> AddCustomClaims(string permissionCode, string userIdString, string companyIdString);
        List<Claim> AddUserInfoClaims(string name, string surname);

    }
}