using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using FunWebAPI.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelsClasslibrary.Users;

namespace FunWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Token _token = null;
        public DataContext _Db { get; }

        public LoginController(IConfiguration config, DataContext db)
        {
            _token = new Token(config, db);
            _Db = db;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User account)
        {
            EFUser login = new EFUser();
            login.Email = account.Email;
            login.Password = account.Password;
            var userdata = _Db.Users.SingleOrDefault(b => b.Email == account.Email && b.Active > 0);
            IActionResult response = Unauthorized();
            var user = _token.AuthenticateUser(login);
            if (user != null)
            {
                var tokenStr = _token.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr, userdata.Username, userdata.UserId });
            }
            return response;
        }
    }
}