using AutoMapper;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Models;
using System.Security.Claims;

namespace HrgAuthApi.Factory
{
    public class TokenDescriptorFactory : ITokenDescriptorFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        List<Claim> _claims;
        public TokenDescriptorFactory(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _claims = new List<Claim>();
        }
        public ClaimsIdentity CreateClaims(int userId, int companyId)
        {
            var userInfo = _userRepository.GetUserInfo(userId, companyId);
            var claimsDto = _mapper.Map<Users, ClaimsDto>(userInfo);
            var customClaims = AddCustomClaims(claimsDto.PermissionCode, claimsDto.UserIdString, claimsDto.CompanyIdString);
            _claims.AddRange(customClaims);
            var userInfoClaims = AddUserInfoClaims(claimsDto.Name, claimsDto.Surname);
            _claims.AddRange(userInfoClaims);
            return new ClaimsIdentity(_claims);
        }
        public List<Claim> AddCustomClaims(string permissionCode, string userIdString, string companyIdString)
        {
            var customClaims = new List<Claim>
            {
                {new Claim("PermissionCode",permissionCode)},
                {new Claim("UserId", userIdString) },
                {new Claim("CompanyId", companyIdString) }
            };
            return customClaims;
        }

        public List<Claim> AddUserInfoClaims(string name, string surname)
        {
            var userInfoClaims = new List<Claim>
            {
                {new Claim(ClaimTypes.Name, name)},
                {new Claim(ClaimTypes.Surname, surname) }
            };
            return userInfoClaims;
        }

    }
}
