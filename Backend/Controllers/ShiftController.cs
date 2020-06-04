using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccesLayer;
using FunWebAPI.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClasslibrary.Shifts;

namespace FunWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftCRUD CRUD;
        private readonly DataContext context;
        public ShiftController(DataContext context)
        {
            CRUD = new ShiftCRUD(context);
        }

        [HttpGet]
        public List<Shift> GetAllForUser(int Id)
        {

            var allShiftData = CRUD.GetAll();
            return allShiftData;

        }

        [HttpGet("{id}")]
        public Shift Get(int Id)
        {

            var shiftData = CRUD.GetById(Id);
            return shiftData;
        }

        [HttpPost]
        public string Add([FromBody] Shift data)
        {
            Shift newShift = new Shift()
            {
                Start = data.Start,
                End = data.End
            };
            
            CRUD.Add(newShift);
            return "Shift has been added.";
        }
        [Route("all")]
        [HttpGet]
        public List<Shift> GetAll()
        {
            List<Shift> allShiftdata = CRUD.GetAll();
            return allShiftdata;
        }
        [HttpDelete("")]
        public string Remove(int Id)
        {
            Shift check = Converter.ToShift(context.Shifts.Find(Id));
            if (check == null)
            {
                return "Shift with Id: " + Id + " does not exist.";
            }
            CRUD.DeleteById(Id);
            return "Shift with Id: " + Id + " has been removed.";
        }
        [HttpPut("")]
        public string Update([FromBody] Shift input)
        {
            if (input.Start == null || input.End == null)
            {
                return "Incorrect data given.";
            }

            Shift updateShift = input;
            CRUD.UpdateById(input.ShiftId, updateShift);
            Shift NewData = CRUD.GetById(input.ShiftId);
            return "Shift succesfully updated.";
        }
    }
}