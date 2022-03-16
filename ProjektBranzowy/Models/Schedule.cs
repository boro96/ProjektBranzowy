using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }

    }
}
