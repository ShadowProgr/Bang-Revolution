using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public interface Role
    {
        int roleID { get; set; }
        string roleName { get; set; }
        string roleDesc { get; set; }
        string img { get; set; }
    }
}
