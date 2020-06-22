using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;

namespace FunWebAPI.CRUD
{
    public class RosterCRUD
    {
        EFRoster Roster = null;

        public RosterCRUD(DataContext db)
        {
            Roster = new EFRoster(db);
        }

        public Roster GetRoster(int id)
        {
            return CheckDates(Roster.GetRoster(id));
        }

        public void AddRoster(int userId, int shiftId)
        {
            EFRoster newRoster = new EFRoster()
            {
                UserId = userId,
                ShiftId = shiftId
            };
            Roster.AddRoster(newRoster);
        }

        private Roster CheckDates(Roster roster)
        {
            foreach (Shift shift in roster.Shifts.ToList())
            {
                if(DateTime.Compare(shift.Start, DateTime.Today) < 0 )
                {
                    roster.Shifts.Remove(shift);
                }
            }
            return roster;
        }


    }
}
