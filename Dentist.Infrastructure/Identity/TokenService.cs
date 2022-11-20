using Dentist.Application.Common.Interfaces;
using Dentist.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dentist.Infrastructure.Identity
{
    public class TokenService : ITokenService
    {
        private readonly AuthOptions _authOptions;

        public TokenService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }

        public string GenerateAccessToken()
        {
            var signInCredentials = new SigningCredentials(
                _authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signInCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

            return encodedToken;
        }
    }
}
