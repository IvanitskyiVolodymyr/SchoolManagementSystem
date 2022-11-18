using Application.Interfaces;
using Domain.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class JwtService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateJsonWebToken(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<string> GenerateRefreshToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("JwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UTCNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
                //new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };

            //Add Roles to claims
            /*var roles = "";

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, "role"));
            }*/
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["expiresInMinutes"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
