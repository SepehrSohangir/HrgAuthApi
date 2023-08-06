using HrgAuthApi.Interfaces;
using System.Security.Claims;

namespace HrgAuthApi.Factory
{
    public class TokenDescriptorFactory : Interfaces.ITokenDescriptorFactory
    {
        IUserRepository _userRepository;
        public Claim[] AddCustomClaims(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Claim[] AddPermissionClaims()
        {
            throw new NotImplementedException();
        }

        public Claim[] AddUserInfoClaims()
        {
            
        }
    }
}
