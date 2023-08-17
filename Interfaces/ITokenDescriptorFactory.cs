using System.Security.Claims;

namespace HrgAuthApi.Interfaces
{
    public interface ITokenDescriptorFactory
    {
        List<Claim> AddCustomClaims(string permissionCode, string userIdString
            , string companyIdString, string moadianSubSystemId);
        List<Claim> AddUserInfoClaims(string name, string surname);
        ClaimsIdentity CreateClaims(int userId, int companyId, int moadianSubSystem);
    }
}