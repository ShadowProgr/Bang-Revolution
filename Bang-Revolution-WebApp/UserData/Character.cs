using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public int skillID { get; set; }
        public int hp { get; set; }
        public string img { get; set; }
        public double price { get; set; }
    }
}
