using HrgAuthApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HrgAuthApi.Builders
{
    public class TokenDescriptorBuilder : ITokenDescriptorBuilder
    {
        private SecurityTokenDescriptor _securityTokenDescriptor;
        public TokenDescriptorBuilder()
        {
            _securityTokenDescriptor = new SecurityTokenDescriptor();
        }
        public ITokenDescriptorBuilder WithSubject(ClaimsIdentity identity)
        {
            _securityTokenDescriptor.Subject = identity;
            return this;
        }
        public ITokenDescriptorBuilder WithIssuedAt(DateTime issuedAt)
        {
            _securityTokenDescriptor.IssuedAt = issuedAt;
            return this;
        }
        public ITokenDescriptorBuilder WithIssuer(string issuer)
        {
            _securityTokenDescriptor.Issuer = issuer;
            return this;
        }
        public ITokenDescriptorBuilder WithAudience(string audience)
        {
            _securityTokenDescriptor.Audience = audience;
            return this;
        }
        public ITokenDescriptorBuilder WithExpirationTime(DateTime expirationTime)
        {
            _securityTokenDescriptor.Expires = expirationTime;
            return this;
        }
        public ITokenDescriptorBuilder WithSigningCredentials(SigningCredentials signingCredentials)
        {
            _securityTokenDescriptor.SigningCredentials = signingCredentials;
            return this;
        }
        public SecurityTokenDescriptor Build()
        {
            return _securityTokenDescriptor;
        }
    }

}
