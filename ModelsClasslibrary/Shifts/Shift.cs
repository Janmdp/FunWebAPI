using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace ModelsClasslibrary.Shifts
{
    public class Shift : IShift
    {
        public int ShiftId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
