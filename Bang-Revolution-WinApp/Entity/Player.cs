using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Player : User
    {
        public List<Card> ownCard { get; set; }
        public Role role { get; set; }
        public Character character { get; set; }
        public int currentHP { get; set; }
        public int maxHP { get; set; }
    }
}
