using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using FunWebAPI.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;

namespace FunWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RosterController : ControllerBase
    {
        private readonly RosterCRUD CRUD;
        private readonly DataContext context;
        public RosterController(DataContext context)
        {
            CRUD = new RosterCRUD(context);
        }

        [HttpGet("")]
        public List<Shift> GetRoster(int Id)
        {
            Roster help = CRUD.GetRoster(Id);
            return help.Shifts;
        }
    }
}