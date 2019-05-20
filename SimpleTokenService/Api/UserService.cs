using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleTokenService.Data;
using SimpleTokenService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTokenService.Api
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly TokenContext _context;

        public UserService(IOptions<AppSettings> appSettings, UserManager<User> userManager, TokenContext context)
        {
            _appSettings = appSettings.Value;
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
                //new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                //new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
             };

            var signingKey = new SigningCredentials(Security.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
               issuer: "ACME", //_options.Issuer,
               audience: "everyone", //_options.Audience,
               claims: claims,
               notBefore: now,
               expires: now.Add(TimeSpan.FromSeconds(300)),
               signingCredentials: signingKey);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
