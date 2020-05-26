using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var trades = _db.Trades.ToList();
            List<Trade> result = new List<Trade>();
            foreach (EFTrade trade in trades)
            {
                Trade newTrade = new Trade()
                {
                    TradeId = trade.TradeId,
                    ShiftId = trade.ShiftId,
                    ReworkShiftId = trade.ReworkShiftId,
                    RequestUserId = trade.RequestUserId,
                };

                EFShift Shift = _db.Shifts.Find(newTrade.ShiftId);
                newTrade.Shift = new Shift()
                {
                    ShiftId = Shift.ShiftId,
                    End = Shift.End,
                    Start = Shift.Start
                };

                EFShift rewShift = _db.Shifts.Find(newTrade.ReworkShiftId);
                newTrade.ReworkShift = new Shift()
                {
                    ShiftId = rewShift.ShiftId,
                    End = rewShift.End,
                    Start = rewShift.Start
                };

                EFUser reqUser = _db.Users.Find(newTrade.RequestUserId);
                newTrade.RequestUser = new User()
                {
                    UserId = reqUser.UserId,
                    Email = reqUser.Email,
                    Username = reqUser.Username
                };

                if (newTrade.AcceptUserId != null)
                {
                    EFUser accUser = _db.Users.Find(newTrade.AcceptUserId);
                    newTrade.RequestUser = new User()
                    {
                        UserId = accUser.UserId,
                        Email = accUser.Email,
                        Username = accUser.Username
                    };
                }
                result.Add(newTrade);
            }
            return result;
        }

        public Trade GetTradeById(int id)
        {
            EFTrade trade = _db.Trades.Find(id);
            
                Trade newTrade = new Trade()
                {
                    TradeId = trade.TradeId,
                    ShiftId = trade.ShiftId,
                    ReworkShiftId = trade.ReworkShiftId,
                    RequestUserId = trade.RequestUserId,
                };

                EFShift Shift = _db.Shifts.Find(newTrade.ShiftId);
                newTrade.Shift = new Shift()
                {
                    ShiftId = Shift.ShiftId,
                    End = Shift.End,
                    Start = Shift.Start
                };

                EFShift rewShift = _db.Shifts.Find(newTrade.ReworkShiftId);
                newTrade.ReworkShift = new Shift()
                {
                    ShiftId = rewShift.ShiftId,
                    End = rewShift.End,
                    Start = rewShift.Start
                };

                EFUser reqUser = _db.Users.Find(newTrade.RequestUserId);
                newTrade.RequestUser = new User()
                {
                    UserId = reqUser.UserId,
                    Email = reqUser.Email,
                    Username = reqUser.Username
                };

                if (newTrade.AcceptUserId != null)
                {
                    EFUser accUser = _db.Users.Find(newTrade.AcceptUserId);
                    newTrade.RequestUser = new User()
                    {
                        UserId = accUser.UserId,
                        Email = accUser.Email,
                        Username = accUser.Username
                    };
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
    }
}
