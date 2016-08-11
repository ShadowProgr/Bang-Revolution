using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Card
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public int effectID { get; set; }
        public int range { get; set; } // 1-13 is Ace to King 
        public int suit { get; set; } //1 is club, 2 is diamond, 3 is heart, 4 is spade
        public bool isEquip { get; set; } //0 is equip, 1 is normal

    }
}
