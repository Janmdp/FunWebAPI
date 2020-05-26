using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFShift : IShift
    {
        private DataContext _db;
        public EFShift(DataContext db)
        {
            _db = db;
        }

        public List<Shift> GetAll()
        {
            var shifts = _db.Shifts.ToList();
            List<Shift> result = new List<Shift>();
            foreach (EFShift shift in shifts)
            {
                result.Add(new Shift()
                {
                    ShiftId = shift.ShiftId,
                    Start = shift.Start,
                    End = shift.End
                });
            }
            return result;
        }

        public IShift GetById(int Id)
        {
            return _db.Shifts.Find(Id);
        }

        public void UpdateById(int id, Shift shift)

        {
            IShift newVersion = shift;
            var result = _db.Shifts.SingleOrDefault(s => s.ShiftId == id);
            if (result != null)
            {
                result.ShiftId = newVersion.ShiftId;
                result.Start = newVersion.Start;
                result.End = newVersion.End;
                _db.SaveChanges();
            }
        }
        public void Add(Shift shift)
        {
            EFShift newShift = new EFShift()
            {
              Start = shift.Start,
              End = shift.End
            };
            _db.Shifts.Add(newShift);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
        }
    }
}

