﻿using ModelsClasslibrary.Shifts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsClasslibrary.Rosters
{
    public class Roster
    {
        public int UserId { get; set; }
        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
