using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;

namespace FunWebAPI.CRUD
{
    public class RosterCRUD
    {
        EFRoster Roster = null;

        public RosterCRUD(DataContext db)
        {
            Roster = new EFRoster(db);
        }

        public void GetRoster(int id)
        {
            Roster.GetRoster(id);
        }
    }
}
