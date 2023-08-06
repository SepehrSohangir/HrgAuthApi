using System.Security.Claims;

namespace HrgAuthApi.Interfaces
{
    public interface ITokenDescriptorFactory
    {
        Claim[] AddUserInfoClaims();
        Claim[] AddPermissionClaims();
        Claim[] AddCustomClaims();
    }
}