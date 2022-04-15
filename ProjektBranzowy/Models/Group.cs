using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
