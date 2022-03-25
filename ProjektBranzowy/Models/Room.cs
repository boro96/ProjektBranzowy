using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string  Name { get; set; }
        public List<LogHistory> LogsHistory { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<User> Users { get; set; }
    }
}
