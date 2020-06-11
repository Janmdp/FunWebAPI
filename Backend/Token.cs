using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FunWebAPI
{
    public class Token
    {
        private IConfiguration _config;
        private DataContext _db;
        public Token(IConfiguration config, DataContext db)
        {
            _config = config;
            _db = db;
        }
        public string GenerateJSONWebToken(EFUser userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var Token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(830),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(Token);
            return encodetoken;
        }
        public EFUser AuthenticateUser(EFUser login)
        {
            //hier checken met DB of credentials kloppen!
            var myUser = _db.Users.FirstOrDefault(u => u.Email == login.Email);
            EFUser user = null;
            if (myUser != null)
            {
                // hash and save a password
                //hashedPassword = BCrypt.Net.BCrypt.HashPassword(submittedPassword);
                if (BCrypt.Net.BCrypt.Verify(login.Password, myUser.Password))
                {
                    user = new EFUser()
                    {
                        Username = myUser.Username,
                        Password = myUser.Password,
                        Email = myUser.Email

                    };
                }
                
            }
            return user;
        }
    }
}
