using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;

namespace Bang_Revolution_Client
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static List<Player> generateDummyData()
        {
            List<Card> cards = new List<Card>();
            Card card = new Card()
            {
                id = 9,
                name = "Bang",
                type = 0,
                img = "Playable Cards\\Bang C2.png",
                effectID = 6,
                rank = 2,
                suit = 1
            };
            cards.Add(card);
            cards.Add(card);
            Card card2 = new Card()
            {
                id = 10,
                name = "Playable Cards\\Panic D8.png",
                type = 0,
                img = "Playable Cards\\Panic D8.png",
                effectID = 9,
                rank = 2,
                suit = 1
            };
            cards.Add(card2);
            Card card3 = new Card()
            {
                id = 10,
                name = "Playable Cards\\Panic D8.png",
                type = 0,
                img = "Playable Cards\\Beer H6.png",
                effectID = 11,
                rank = 2,
                suit = 1
            };
            cards.Add(card3);
            List<Player> players = new List<Player>();
            for (int i = 0; i < 7; i++)
            {
                Role role = new Role()
                {
                    id = 1,
                    name = "Sheriff",
                    desc = "n/a",
                    img = "sheriff.png"
                };
                Character character = new Character()
                {
                    id = 1,
                    name = "Test char",
                    desc = "n/a",
                    hp = 5,
                    skillID = 1,
                    img = "Characters\\El Gringo.png",
                    price = 500
                };
                Player player = new Player()
                {
                    cardsOnHand = cards,
                    id = i,
                    role = role,
                    name = "player " + i,
                    currentHP = character.hp,
                    maxHP = character.hp,
                    character = character,
                    distance = 0,
                    range = 2,
                    scope = 1,
                    usedBang = false
                };
                players.Add(player);
            }
            return players;
        }
    }
}
