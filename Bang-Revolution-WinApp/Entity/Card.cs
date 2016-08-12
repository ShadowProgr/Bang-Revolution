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
        public int type { get; set; } //0 is normal, 1 is gun, 2 is range, 3 distance, 4 barrel, 5 jail, 6 dynomite

    }
}
