using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsClasslibrary;
using DataAccesLayer;
using FunWebAPI.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ModelsClasslibrary.Users;


namespace FunWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserCRUD CRUD;
        private readonly DataContext context;
        public UserController(DataContext context)
        {
            CRUD = new UserCRUD(context);
        }

        [HttpGet]
        public string Get(int Id)
        {
            
            var alluserdata = CRUD.GetById(Id);
            var result = JsonSerializer.Serialize(alluserdata);
            return result;
        }

        [HttpGet("all")]
        public List<User> GetAll()
        {
            List<User> alluserdata = CRUD.GetAll();
            foreach (User obj in alluserdata.ToList())
            {
                if (obj.Active == 0)
                {
                    alluserdata.Remove(obj);
                }
            }
            
            return alluserdata;
        }

        [HttpPost]
        public void Add(User data)
        {
            User account = new User();
            account.Username = data.Username;
            account.Password = BCrypt.Net.BCrypt.HashPassword(data.Password, 10);
            account.Email = data.Email;
            account.Active = 1;
            CRUD.Add(account);
            //return "User " + account.Username + " has been added.";
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Remove(int Id)
        {
            User check = CRUD.DeleteById(Id);
            if (check == null)
            {
                return NotFound();
            }
            return check;
        }

        [HttpPut]
        public string Update([FromBody] User input)
        {
            if (input.Username == null  || input.Email == null || input.Username == "" || input.Email == "")
            {
                return "Incorrect data given.";
            }
            if (input.Active == 2)
            {
                return "You cant change data from the ADMIN account.";
            }

            User oldData = CRUD.GetById(input.UserId); 
            User updateUser = input;
            if (updateUser.Password != null)
            {
                updateUser.Password = BCrypt.Net.BCrypt.HashPassword(updateUser.Password, 10);
            }
            CRUD.UpdateById(input.UserId, updateUser);
            User NewData = CRUD.GetById(input.UserId);
            return "User succesfully updated.";
        }
    }
}
