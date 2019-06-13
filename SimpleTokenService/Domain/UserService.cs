using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleTokenService.Data;
using SimpleTokenService.Data.Entities;
using SimpleTokenService.Domain.Core;
using SimpleTokenService.Domain.Interfaces;
using SimpleTokenService.Domain.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTokenService.Domain
{
    public class UserService : IUserService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        private readonly TokenContext _context;

        public UserService(JwtSettings jwtSettings, UserManager<User> userManager, TokenContext context)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            if (!await _userManager.CheckPasswordAsync(user, password)) return null;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", "Admin"),
                new Claim("role", "User"),
                new Claim("role", "SystemAdmin")
                //new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
             };

            var signingKey = new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key)),
                   SecurityAlgorithms.HmacSha256Signature
            );

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               notBefore: now,
               expires: now.AddMinutes(_jwtSettings.MinutesToExpiration),
               signingCredentials: signingKey);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
