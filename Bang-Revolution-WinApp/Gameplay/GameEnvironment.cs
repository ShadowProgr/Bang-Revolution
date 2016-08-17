using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace Gameplay
{
    public class GameEnvironment
    {

        public List<Player> players = new List<Player>();
        public List<Card> deck = new List<Card>();
        public List<Card> removedDeck = new List<Card>();
        public List<Role> roles = new List<Role>();

        public int gameResult = 0;
        public int turn = 0;

        public void initGame(List<User> users)
        {
            initData();
            initPlayers(users);
            setFirstPlayer();
        }

        public void initData()
        {
            ConnectToDB dbAccess = new ConnectToDB();
            roles = dbAccess.getRoles();
            deck = dbAccess.getCard();
            deck = BasicOperations.shuffleCards(deck);
        }

        public void initPlayers(List<User> users)
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
                            players.Add(initOnePlayer(users.ElementAt(i), 1));
                            sheriffCount--;
                            i++;
                        }
                        break;
                    case 2:
                        if (deputyCount != 0)
                        {
                            players.Add(initOnePlayer(users.ElementAt(i), 2));
                            deputyCount--;
                            i++;
                        }
                        break;
                    case 3:
                        if (outlawCount != 0)
                        {
                            players.Add(initOnePlayer(users.ElementAt(i), 3));
                            outlawCount--;
                            i++;
                        }
                        break;
                    case 4:
                        if (renegadeCount != 0)
                        {
                            players.Add(initOnePlayer(users.ElementAt(i), 4));
                            renegadeCount--;
                            i++;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        public Player initOnePlayer(User user, int roleID)
        {
            Player player = new Player();
            player.cardsOnHand = new List<Card>();
            foreach (Role role in roles)
            {
                if (role.id == roleID)
                {
                    player.role = role;
                }
            }
            ConnectToDB dbAccess = new ConnectToDB();
            List<Character> ownedChars = dbAccess.getCharbyUserID(user.id);
            player.character = ownedChars.ElementAt(0);
            player.maxHP = player.character.hp;
            player.currentHP = player.maxHP; // Hard code, needs change
            player.distance = 1; // Hard code, needs change
            player.range = 1; // Hard code, needs change
            player.usedBang = false;
            for (int i = 0; i < player.currentHP; i++)
            {
                BasicOperations.drawCard(player, deck);
            }
            return player;
        }

        public void setFirstPlayer()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players.ElementAt(i).role.id == 1)
                {
                    turn = i;
                    break;
                }
            }
        }

        public void startTurn()
        {
            // Prompt current user for action
        }

        public void endTurn()
        {
            // Starts when current user hits end turn
            if (turn < players.Count - 1)
            {
                turn++;
            } else
            {
                turn = 0;
                startTurn();
            }
        }
    }
}
