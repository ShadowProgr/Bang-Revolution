using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Player: User, Role
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public string roleDesc { get; set; }
        public string img { get; set; }
        
    }
}
