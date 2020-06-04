using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Trades;
using ModelsClasslibrary.Users;

namespace DataAccesLayer
{
    public static class Converter
    {
        //Conversion Methods
        public static EFShift ToEfShift(Shift shift)
        {
            EFShift newShift = new EFShift()
            {
                ShiftId = shift.ShiftId,
                Start = shift.Start,
                End = shift.End
            };

            return newShift;
        }

        public static Shift ToShift(EFShift EFShift)
        {
            Shift newShift = new Shift()
            {
                ShiftId = EFShift.ShiftId,
                Start = EFShift.Start,
                End = EFShift.End
            };

            return newShift;
        }

        public static EFUser ToEfUser(User user)
        {
            EFUser newUser = new EFUser()
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Active = user.Active
            };

            return newUser;
        }

        public static User ToUser(EFUser EFUser)
        {
            User newUser = new User()
            {
                UserId = EFUser.UserId,
                Username = EFUser.Username,
                Email = EFUser.Email,
                Password = EFUser.Password,
                Active = EFUser.Active
            };

            return newUser;
        }


        public static EFRoster ToEfRoster(Roster roster)
        {
            EFRoster newRoster = new EFRoster()
            {
                UserId = roster.UserId,
                ShiftId = roster.ShiftId,
                Shifts = roster.Shifts
            };

            return newRoster;
        }

        public static Roster ToRoster(EFRoster efroster)
        {
            Roster newRoster = new Roster()
            {
                UserId = efroster.UserId,
                ShiftId = efroster.ShiftId,
                Shifts = efroster.Shifts
            };

            return newRoster;
        }

        public static EFTrade ToEfTrade(Trade trade)
        {
            EFTrade newTrade = new EFTrade()
            {
                TradeId = trade.TradeId,
                Shift = ToEfShift(trade.Shift),
                ReworkShift = ToEfShift(trade.ReworkShift),
                RequestUser = ToEfUser(trade.RequestUser),
                AcceptUser = ToEfUser(trade.AcceptUser)
            };

            return newTrade;
        }

        public static Trade ToTrade(EFTrade eftrade)
        { 
            Trade newTrade = new Trade()
            {
                TradeId = eftrade.TradeId,
                Shift = ToShift(eftrade.Shift),
                ReworkShift = ToShift(eftrade.ReworkShift),
                RequestUser = ToUser(eftrade.RequestUser),
            };
            if (eftrade.AcceptUser != null)
            {
                newTrade.AcceptUser = ToUser(eftrade.AcceptUser);
            }

            return newTrade;
        }
    }

    
}
