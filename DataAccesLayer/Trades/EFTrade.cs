using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Trades;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFTrade
    {
        private DataContext _db;
        private EFRoster rost;
        public EFTrade(DataContext db)
        {
            _db = db;
            rost = new EFRoster(db);
        }

        public List<Trade> GetAll(int userId)
        {
            
            Roster roster = rost.GetRoster(userId);
            var trades = _db.Trades.Include("Shift").Include("ReworkShift").Include("RequestUser").Include("AcceptUser").Where(t => t.AcceptUserId == null)
                .ToList();
            List<Trade> result = new List<Trade>();
            foreach (EFTrade trade in trades)
            {
                foreach (Shift shift in roster.Shifts )
                {
                    //I should not work on the day he wants me to work.
                    //I should work on the day he wants to work back
                    if (trade.Shift.ShiftId != shift.ShiftId && trade.ReworkShift.ShiftId == shift.ShiftId)
                    {
                        Trade newTrade = Converter.ToTrade(trade);
                        result.Add(newTrade);
                        
                    }
                    else
                    {
                        //nothing cabron
                    }
                }
               
            }
            return result;
        }

        public Trade GetTradeById(int id)
        {
            var trade = _db.Trades.Include("Shift").Include("ReworkShift").Include("RequestUser").Include("AcceptUser")
                .Where(t => t.TradeId == id).ToList();
            Trade newTrade = new Trade();
            foreach (EFTrade trad in trade )
            { 
                newTrade = Converter.ToTrade(trad);
            }

            return newTrade;
        }

        public string CreateTrade(Trade newTrade)
        {
            EFTrade add = new EFTrade()
            {
                RequestUserId = newTrade.RequestUserId,
                ReworkShiftId = newTrade.ReworkShiftId,
                ShiftId = newTrade.ShiftId
            };

            _db.Trades.Add(add);
            _db.SaveChanges();
            return "Trade has been added";
        }

        public string DeleteTrade(int id)
        {
            try
            {
                _db.Trades.Remove(_db.Trades.Single(t => t.TradeId == id));
                _db.SaveChanges();
                return "Trade has been removed";
            }
            catch
            {
                return "Oops something went wrong";
            }
        }

        public string CompleteTrade(Trade Complete)
        {

                Trade newversion = Complete;
                var tradeResult = _db.Trades.Include("Shift").Include("ReworkShift").Include("RequestUser").Include("AcceptUser").SingleOrDefault(t => t.TradeId == newversion.TradeId);
                if (tradeResult != null)
                {
                    tradeResult.AcceptUserId = newversion.AcceptUser.UserId;
                _db.SaveChanges();
                }

                var shiftResult = _db.Rosters.SingleOrDefault(s =>
                    s.ShiftId == newversion.Shift.ShiftId && s.UserId == newversion.RequestUser.UserId);
                if (shiftResult != null)
                {
                    shiftResult.UserId = newversion.AcceptUser.UserId;
                _db.SaveChanges();
                }

                var reworkShiftResult = _db.Rosters.SingleOrDefault(rs =>
                    rs.ShiftId == newversion.ReworkShift.ShiftId && rs.UserId == newversion.AcceptUser.UserId);
                if (reworkShiftResult != null)
                {
                    reworkShiftResult.UserId = newversion.RequestUser.UserId;
                _db.SaveChanges();
                }
                
                return
                    $"yes";
           
        }
    }
}
