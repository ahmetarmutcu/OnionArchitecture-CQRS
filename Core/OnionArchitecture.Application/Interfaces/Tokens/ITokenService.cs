using OnionArchitecture.Domain.Entites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnionArchitecture.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken();
    }
}
