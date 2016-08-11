using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Gameplay
{
    public class GameEnvironment
    {

        public List<Player> players = new List<Player>();

        public void initGame(List<User> users)
        {
            assignRoles(users);

        }

        public void assignRoles(List<User> users)
        {
            int noOfPlayers = users.Count;
            int sheriffCount;
            int deputyCount;
            int outlawCount;
            int renegadeCount;
            switch (noOfPlayers)
            {
                case 4:
                    sheriffCount = 1;
                    deputyCount = 0;
                    outlawCount = 2;
                    renegadeCount = 1;
                    break;
                case 5:
                    sheriffCount = 1;
                    deputyCount = 1;
                    outlawCount = 2;
                    renegadeCount = 1;
                    break;
                case 6:
                    sheriffCount = 1;
                    deputyCount = 1;
                    outlawCount = 3;
                    renegadeCount = 1;
                    break;
                case 7:
                    sheriffCount = 1;
                    deputyCount = 2;
                    outlawCount = 3;
                    renegadeCount = 1;
                    break;
                default:
                    return;
            }
            for (int i = 0; i < noOfPlayers;)
            {
                Random rnd = new Random();
                int role = rnd.Next(1, 5);
                switch (role)
                {
                    case 1:
                        if (sheriffCount != 0)
                        {
                            // Assign sheriff role to player
                            sheriffCount--;
                            i++;
                        }
                        break;
                    case 2:
                        if (deputyCount != 0)
                        {
                            // Assign deputy role to player
                            deputyCount--;
                            i++;
                        }
                        break;
                    case 3:
                        if (outlawCount != 0)
                        {
                            // Assign outlaw role to player
                            outlawCount--;
                            i++;
                        }
                        break;
                    case 4:
                        if (renegadeCount != 0)
                        {
                            // Assign renegade role to player
                            renegadeCount--;
                            i++;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        public void cardBang(Player shooter, Player receiver)
        {

        }

        public void takeDamage(Player victim, int damage)
        {
            
        } 
    }
}
