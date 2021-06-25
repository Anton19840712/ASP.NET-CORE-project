using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Bussiness.DTOs;
using Web.DAL.Models;

namespace Web.Bussiness.Services.AccountManagement
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly AppIdentityDbContext _context;

        //database sample:
        private readonly List<AppUser> _appUsers = new List<AppUser>
        {
            new AppUser
            {
                Id = "18a47106-2692-46de-96f2-d485eb2c0bec",
                Login = "qwerty@gmail.com",
                Password = "12345",
                Role = "Admin"
            },
            new AppUser
            {
                Id = "625bd154-d0ef-49b7-bdcb-d917c607642c",
                Login = "asdfg@gmail.com",
                Password = "55555",
                Role = "Power user"
            }
        };

        public TokenService(IConfiguration configuration, AppIdentityDbContext context)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            _context = context;
        }

        public async Task<string> CreateToken(TokenModelDto tokenModelDto)
        {
            var result = await _context.Products.FindAsync(34);

            //user tries to insert its credentials:
            var appUser = _appUsers.FirstOrDefault(x => x.Login == tokenModelDto.UserName && x.Password == tokenModelDto.Password);
            if (appUser == null) return null;

            //if user exists, then we give him claims:
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, appUser.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, appUser.Role),
                new Claim(JwtRegisteredClaimNames.NameId, appUser.Id)
            };

            // set him credentials:
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // create token description:
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // and create token for him:
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // get token:
            var tokenToReturn = tokenHandler.WriteToken(token);

            // return token data to the code place as anonymous type, where we need it:
            var response = new
            {
                access_token = tokenToReturn,
                username = appUser.LastName,
                userId = appUser.Id // ⇐ we need this one
            };

            return claims.FirstOrDefault(i => i.Type == JwtRegisteredClaimNames.NameId)?.Value;
        }
    }
}