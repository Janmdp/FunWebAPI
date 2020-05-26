using System;
using System.Collections.Generic;
using System.Text;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;

namespace ModelsClasslibrary.Trades
{
    public interface ITrade
    {
        int TradeId { get; }
        int ShiftId { get; }
        Shift Shift { get; }
        int ReworkShiftId { get; }
        Shift ReworkShift { get; }
        int RequestUserId { get; }
        User RequestUser { get; }
        int AcceptUserId { get; }
        User AcceptUser { get; }
    }
}
