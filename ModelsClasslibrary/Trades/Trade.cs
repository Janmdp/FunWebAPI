using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsClasslibrary.Trades
{
    public class Trade
    {
        public int TradeId { get; set; }

        public Shift Shift { get; set; }

        public Shift ReworkShift { get; set; }

        public User RequestUser { get; set; }

        public User AcceptUser { get; set; }

        public int ShiftId { get; set; }

        public int ReworkShiftId { get; set; }

        public int RequestUserId { get; set; }

        public int AcceptUserId { get; set; }

    }
}
