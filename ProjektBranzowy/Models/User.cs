using System;
using System.Collections.Generic;
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
        public string Group { get; set; }
        public bool IsAdmin { get; set; }
        public List<int> Access { get; set; } = new List<int>();
        public string  Password { get; set; }


    }
}
