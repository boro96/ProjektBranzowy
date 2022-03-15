using Microsoft.EntityFrameworkCore;
using ProjektBranzowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.DataAccess
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions options) : base(options) { }
       public DbSet<User> People { get; set; }
       public DbSet<Room> Rooms { get; set; }
       public DbSet<LogHistory> LogsHistory{ get; set; }
    }
}
