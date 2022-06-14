using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class UnauthorizedAccess
    {
        public int UnauthorizedAccessId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime In { get; set; }
        public DateTime Out { get; set; }
    }
}
