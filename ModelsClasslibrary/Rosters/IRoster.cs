using System;
using System.Collections.Generic;
using System.Text;
using ModelsClasslibrary.Shifts;

namespace ModelsClasslibrary
{
    public interface IRoster
    {
        int UserId { get; }
        int ShiftId { get; }
        List<Shift> Shifts { get; }
    }
}
