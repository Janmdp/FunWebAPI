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

        [HttpGet("Id")]
        public string Get(int Id)
        {
            
            var alluserdata = CRUD.GetById(Id);
            var result = JsonSerializer.Serialize(alluserdata);
            return result;
        }

        [HttpGet]
        public string GetAll()
        {
            List<User> alluserdata = CRUD.GetAll();
            foreach (User obj in alluserdata.ToList())
            {
                if (obj.Active == 0)
                {
                    alluserdata.Remove(obj);
                }
            }
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(alluserdata);
            return result;
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
            if (input.Username == null || input.Password == null || input.Email == null || input.Username == "" || input.Password == "" || input.Email == "")
            {
                return "Incorrect data given.";
            }
            if (input.Active == 2)
            {
                return "You cant change data from the ADMIN account.";
            }

            User oldData = CRUD.GetById(input.UserId); 
            User updateUser = input;
            CRUD.UpdateById(input.UserId, updateUser);
            User NewData = CRUD.GetById(input.UserId);
            return "User succesfully updated.";
        }
    }
}
