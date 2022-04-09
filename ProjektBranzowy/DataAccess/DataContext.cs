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
       public DbSet<Schedule> Schedules { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var users = modelBuilder.Entity<User>();
            users.Property(a => a.Name).HasColumnType("varchar(50)").IsRequired();
            users.Property(b => b.Surname).HasColumnType("varchar(50)").IsRequired();
            users.Property(c => c.Email).HasColumnType("varchar(60)").IsRequired();
            users.Property(di => di.Group).HasColumnType("char(6)");
            users.Property(m => m.Password).HasColumnType("varchar(30)").IsRequired();


            modelBuilder.Entity<Room>()
                .Property(a => a.Name).HasColumnType("varchar(40)").IsRequired();


            modelBuilder.Entity<LogHistory>()
                .HasOne(a => a.User)
                .WithMany(b => b.LogsHistory)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<LogHistory>()
                .HasOne(a => a.Room)
                .WithMany(b => b.LogsHistory)
                .HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Schedule>()
                .HasOne(a => a.User)
                .WithMany(b => b.Schedules)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Schedule>()
                .HasOne(a => a.Room)
                .WithMany(b => b.Schedules)
                .HasForeignKey(c => c.RoomId);
        }
    }
}
