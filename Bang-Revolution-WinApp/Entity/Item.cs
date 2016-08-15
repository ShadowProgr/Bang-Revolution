using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string img { get; set; }
        public bool isBackground { get; set; } //1 is background, 0 is back card
    }
}
