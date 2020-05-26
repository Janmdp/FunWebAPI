using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFShift> Shifts { get; set; }
        public DbSet<EFRoster> Rosters { get; set; }
        public DbSet<EFTrade> Trades { get; set; }
    }
}
