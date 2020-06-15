using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Trades;

namespace FunWebAPI.CRUD
{
    public class TradeCRUD
    {
        EFTrade Trade = null;

        public TradeCRUD(DataContext db)
        {
            Trade = new EFTrade(db);
        }

        public List<Trade> GetAll(int userId)
        {
            return Trade.GetAll(userId);
        }

        public Trade GetById(int id)
        {
            return Trade.GetTradeById(id);
        }

        public string DeleteTrade(int id)
        {
            return Trade.DeleteTrade(id);
        }

        public string CompleteTrade(Trade trade)
        {
            return Trade.CompleteTrade(trade);
        }

        public string CreateTrade(Trade trade)
        {
            return Trade.CreateTrade(trade);
        }
    }
}
