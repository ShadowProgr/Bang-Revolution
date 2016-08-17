using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
    }
}
