using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Player : User
    {
        public List<Card> ownCard { get; set; }
        public List<Card> currentEquip { get; set; }
        public Role role { get; set; }
        public Character character { get; set; }
        public int currentHP { get; set; }
        public int maxHP { get; set; }
        public int range { get; set; }
        public int distance { get; set; }
        public bool hasBang { get; set; }
    }
}
