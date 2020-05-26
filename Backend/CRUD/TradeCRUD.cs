using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Trades;

namespace FunWebAPI.CRUD
{
    public class TradeCRUD
    {
        EFTrade Trade = null;

        public TradeCRUD(DataContext db)
        {
            Trade = new EFTrade(db);
        }
    }
}
