using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Shifts;

namespace FunWebAPI.CRUD
{

    public class ShiftCRUD
    {
        EFShift Shift = null;

        public ShiftCRUD(DataContext db)
        {
            Shift = new EFShift(db);
        }
        public void DeleteById(int Id)
        {
            Shift.DeleteById(Id);
        }

        public List<Shift> GetAll()
        {
            return Shift.GetAll();
        }

        public IShift GetById(int Id)
        {
            return Shift.GetById(Id);
        }

        public void UpdateById(int id, Shift update)
        {
            Shift.UpdateById(id, update);
        }

        public void Add(Shift newShift)
        {
            Shift.Add(newShift);
        }

    }
}
