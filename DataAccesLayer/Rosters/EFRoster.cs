using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;
using MySql.Data.MySqlClient;

namespace DataAccesLayer.EntityFramework
{
    
    public partial class EFRoster
    {
        private DataContext _db;
        
        public EFRoster(DataContext db)
        {
            _db = db;
        }

        public void AddRoster(EFRoster newRoster)
        {
            _db.Rosters.Add(newRoster);
            _db.SaveChanges();
        }
        public Roster GetRoster(int id)
        {
            //var shifts =  _db.Rosters.Join(_db.Users,
            //                                            ru => ru.UserId,
            //                                            u => u.UserId,
            //                                            ((roster, user) => new
            //                                            {
            //                                              userId = user.UserId,
            //                                              shiftId = roster.ShiftId
            //                                            })).Where(r => r.userId == id).Join(_db.Shifts,
            //                                                                                              rs => rs.shiftId,
            //                                                                                              s => s.ShiftId,
            //                                                                                              (temp, shift) => new EFShift()
            //                                                                                              {
            //                                                                                                   ShiftId = shift.ShiftId,
            //                                                                                                   End = shift.End,
            //                                                                                                   Start = shift.Start
            //                                                                                              });
            //Roster newRoster = new Roster();
            //foreach (EFShift shift in shifts )
            //{
            //    Shift newShift = new Shift()
            //    {
            //        ShiftId = shift.ShiftId,
            //        End = shift.End,
            //        Start = shift.Start
            //    };
            //    newRoster.Shifts.Add(newShift);
            //}

            var rosters = _db.Rosters.Include("Shift").Where(u => u.UserId == id);

            Roster newRoster = new Roster();
            foreach (EFRoster roster in rosters )
            {
                Shift newShift = new Shift()
                {
                    ShiftId = roster.Shift.ShiftId,
                    End = roster.Shift.End,
                    Start = roster.Shift.Start
                };
                newRoster.Shifts.Add(newShift);
            }
            return newRoster;
        }
    }
}
