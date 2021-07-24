using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using Auth.Models.DTO;

namespace Auth.Services
{
    public class TokenService: ITokenService
    {
        public IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            return builder.Build();
        }
        public string GenerateToken(UserDto permissoes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetKey();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, permissoes.Username)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private byte[] GetKey()
        {
            var Config = GetConfig();
            var secret = Config.GetSection("Settings:Secret").Value;
            return Encoding.ASCII.GetBytes(secret);
        }
    }
}