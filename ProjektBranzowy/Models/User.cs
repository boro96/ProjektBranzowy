using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  Email { get; set; } 
        public bool IsAdmin { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string  Password { get; set; }
        public List<LogHistory> LogsHistory { get; set; }
        public List<Schedule> Schedules { get; set; }
        public int GroupId { get; set; }
        [NotMapped]
        public Group Groups { get; set; }



    }
}
