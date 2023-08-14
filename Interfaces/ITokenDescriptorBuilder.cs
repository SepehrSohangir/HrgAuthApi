using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HrgAuthApi.Interfaces
{
    public interface ITokenDescriptorBuilder
    {
        ITokenDescriptorBuilder WithSubject(ClaimsIdentity identity);
        ITokenDescriptorBuilder WithIssuedAt(DateTime issuedAt);
        ITokenDescriptorBuilder WithIssuer(string issuer);
        ITokenDescriptorBuilder WithAudience(string audience);
        ITokenDescriptorBuilder WithExpirationTime(DateTime expirationTime);
        ITokenDescriptorBuilder WithSigningCredentials(SigningCredentials signingCredentials);
        SecurityTokenDescriptor Build();

    }
}