using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Trades;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFTrade
    {
        private DataContext _db;
        public EFTrade(DataContext db)
        {
            _db = db;
        }

        public List<Trade> GetAll()
        {
            var trades = _db.Trades.Include("Shift").Include("ReworkShift").Include("RequestUser").Include("AcceptUser")
                .ToList();
            List<Trade> result = new List<Trade>();
            foreach (EFTrade trade in trades)
            {
                Trade newTrade = Converter.ToTrade(trade);
                result.Add(newTrade);
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
            try
            {
                Trade newversion = Complete;
                var tradeResult = _db.Trades.SingleOrDefault(t => t.TradeId == newversion.TradeId);
                if (tradeResult != null)
                {
                    tradeResult.AcceptUserId = newversion.AcceptUserId;
                    tradeResult.AcceptUser = Converter.ToEfUser(newversion.AcceptUser);
                }

                var shiftResult = _db.Rosters.SingleOrDefault(s =>
                    s.ShiftId == newversion.Shift.ShiftId && s.UserId == newversion.AcceptUser.UserId);
                if (shiftResult != null)
                {
                    shiftResult.UserId = newversion.RequestUser.UserId;
                    shiftResult.User = Converter.ToEfUser(newversion.RequestUser);
                }

                var reworkShiftResult = _db.Rosters.SingleOrDefault(rs =>
                    rs.ShiftId == newversion.ReworkShift.ShiftId && rs.UserId == newversion.AcceptUser.UserId);
                if (reworkShiftResult != null)
                {
                    reworkShiftResult.UserId = newversion.AcceptUser.UserId;
                    reworkShiftResult.User = Converter.ToEfUser(newversion.AcceptUser);
                }
                _db.SaveChanges();
                return
                    $"{shiftResult.User.Username} now works on {shiftResult.Shift.Start.Date}, and {reworkShiftResult.User.Username} now works on {reworkShiftResult.Shift.Start.Date}";
            }
            catch
            {
                return "Oops something went wrong";
            }
        }
    }
}
