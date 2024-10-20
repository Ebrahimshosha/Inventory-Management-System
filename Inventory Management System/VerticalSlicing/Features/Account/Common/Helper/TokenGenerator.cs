﻿
namespace FoodApp.Api.VerticalSlicing.Features.Account.Common.Helper
{
    public static class TokenGenerator
    {
        public static JwtOptions options { get; set; } = null!;

        public static string GenerateToken(User user)
        {
            var claims = new ClaimsIdentity(new Claim[]
            {
            new Claim("UserId", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

            if (user.Role != null)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, user.Role.Name));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = options.Issuer,
                Audience = options.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(options.ExpiryMinutes),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}