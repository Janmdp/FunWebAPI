using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsClasslibrary.Shifts
{
    public interface IShift
    {
        int ShiftId { get; }
        DateTime Start { get; }
        DateTime End { get; }
    }
}
