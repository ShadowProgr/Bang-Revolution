using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Gameplay
{
    public static class BasicOperations
    {
        public static void drawCard(Player player, List<Card> currentCard)
        {
            player.ownCard.Add(currentCard[0]);
            currentCard.RemoveAt(0);
        }

        public static void drawFromRemoveCard(Player player, List<Card> removeCard)
        {
            player.ownCard.Add(removeCard[0]);
            removeCard.RemoveAt(0);
        }

        public static List<Card> shuffleCard(List<Card> shuffle)
        {
            List<Card> newList = new List<Card>();
            List<int> check = new List<int>();
            foreach (Card card in shuffle)
            {
                Random rd = new Random();
                int i = rd.Next(0, shuffle.Count);
                while (check.Contains(i)) {
                    i = rd.Next(0, shuffle.Count);
                } 
                newList.Add(shuffle[i]);
                check.Add(i);
            }
            return newList;
        }

        public static Card checkCard(List<Card> removeCard, List<Card> currentCard)
        {
            Card card = currentCard[0];
            showCard(card);
            removeCard.Add(currentCard[0]);
            currentCard.RemoveAt(0);
            return card;
        }

        public static void removeCard(List<Card> removeCard, Player player, Card card)
        {
            removeCard.Add(card);
            player.ownCard.Remove(card);
        }

        public static void drawFromAnother(Player actor, Player receiver, Card card)
        {
            actor.ownCard.Add(card);
            receiver.ownCard.Remove(card);
        }

        public static void equipCard(Player actor, Player receiver, Card card)
        {
            Card c = null;
            switch (card.type)
            {
                case 1:
                    c = checkTypeEquip(receiver, 1);
                    break;
                case 2:
                    c = checkTypeEquip(receiver, 2);
                    break;
                case 3:
                    c = checkTypeEquip(receiver, 3);
                    break;
                case 4:
                    c = checkTypeEquip(receiver, 4);
                    break;
                case 5:
                    c = checkTypeEquip(receiver, 5);
                    break;
                case 6:
                    c = checkTypeEquip(receiver, 6);
                    break;

            }
            if (c != null)
            {
                unequipCard(receiver, c);
            }
            receiver.currentEquip.Add(card);
            actor.ownCard.Remove(card);
            
        }

        public static Card checkTypeEquip(Player player, int type)
        {
            foreach (Card card in player.currentEquip)
            {
                if (card.type == type)
                {
                    return card;
                }
            }
            return null;
        }

        public static void unequipCard(Player receiver, Card card)
        {
            receiver.currentEquip.Remove(card);
        }

        public static Card sendPickCardRequest(Player player, List<Card> pickCard)
        {
            Card c = new Card();
            //send request to player to choose a card in pickCard
            return c;
        }

        public static Player sendPickPlayerRequet(Player player, List<Player> playersInRange)
        {
            Player p = new Player();
            //send request to player to choose a player in playersInRange
            return p;
        }

        public static void showCard(Card card)
        {
            //show card
        }
        
    }
}
