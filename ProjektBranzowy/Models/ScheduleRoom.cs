using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class ScheduleRoom
    {
        public int ScheduleRoomId { get; set; }
        public int WeekDay { get; set; }

        [NotMapped]
        public string WeekDayName
        {
            get
            {
                return Enum.GetName(typeof(DayOfWeek), WeekDay-1);
            }
        }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
    }
}
