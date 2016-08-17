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
                    img = "char.png",
                    price = 500
                };
                Player player = new Player()
                {
                    role = role,
                    name = "player " + i,
                    currentHP = character.hp,
                    maxHP = character.hp,
                    character = character,
                    distance = 1,
                    range = 1
                };
                players.Add(player);
            }
            return players;
        }
    }
}
