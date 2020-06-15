using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using FunWebAPI.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsClasslibrary.Trades;

namespace FunWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TradeController : Controller
    {
        private readonly TradeCRUD CRUD;
        private readonly DataContext context;
        public TradeController(DataContext context)
        {
            CRUD = new TradeCRUD(context);
        }

        [HttpGet("all")]
        public List<Trade> GetAll(int Id)
        {
            var result = CRUD.GetAll(Id);
            return result;
        }

        [HttpGet]
        public Trade GetById(int id)
        {
            var result = CRUD.GetById(id);
            return result;
        }

        [HttpDelete]
        public string DeleteTrade(int id)
        {
            return CRUD.DeleteTrade(id);
        }

        [HttpPost]
        public string CreateTrade(Trade trade)
        {
            return CRUD.CreateTrade(trade);
        }

        [HttpPut]
        public string CompleteTrade(Trade trade)
        {
            Trade test = new Trade();
            test = trade;
            return CRUD.CompleteTrade(trade);
        }
    }
}