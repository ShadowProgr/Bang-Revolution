using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Gameplay
{
    public static class CardEffect
    {
        //volcanic
        public static void CE01(Player player)
        {
            player.usedBang = true;
        }

        //gun 2
        public static void CE02(Player player)
        {
            player.range = 2;
        }

        //gun 3
        public static void CE03(Player player)
        {
            player.range = 3;
        }

        //gun 4
        public static void CE04(Player player)
        {
            player.range = 4;
        }

        //gun 5
        public static void CE05(Player player)
        {
            player.range = 5;
        }

        //bang return true if able to bang
        public static bool CE06(Player victim, List<Card> removeCard, List<Card> currentCard)
        {
            foreach (Card card in victim.currentEquip)
            {
                if (card.id == 20 && CE20(victim, removeCard, currentCard))
                {
                    return false;
                }
            }
            if (victim.character.skillID == 6 && CharacterSkill.SkillID6(victim, currentCard, removeCard))
            {
                return false;
            }
            Card c = new Card();
            //send a miss request to victim
            if (CE07(victim, c))
            {
                return false;
            }
            return true;
        }

        //return true for able to miss
        public static bool CE07(Player player, Card c)
        {
            if (c.id == 7)
            {
                return true;
            }
            return false;
        }

        //beer
        public static void CE08(Player player)
        {
            if (player.maxHP < 5)
            {
                player.maxHP++;
            }
            if (player.currentHP < player.maxHP)
            {
                player.currentHP++;
            }
        }

        //panic
        public static void CE09(Player actor, Player victim)
        {
            Card c = new Card();
            // send a request to choose hand or field cards
            if (true) //if field
            {
                c = BasicOperations.sendPickCardRequest(actor, victim.currentEquip);
            }
            else
            {
                c = BasicOperations.sendPickCardRequest(actor, victim.cardsOnHand);
            }
            BasicOperations.drawFromAnother(actor, victim, c);
        }

        //cat blou
        public static void CE10(Player actor, Player victim, List<Card> removeCard)
        {
            Card c = new Card();
            // send a request to choose hand or field cards
            if (true) //if field
            {
                c = BasicOperations.sendPickCardRequest(actor, victim.currentEquip);
            }
            else
            {
                c = BasicOperations.sendPickCardRequest(actor, victim.cardsOnHand);
            }
            BasicOperations.removeCard(removeCard, victim, c);
        }

        //draw 2 card
        public static void CE11(Player player, List<Card> currentCard)
        {
            BasicOperations.drawCard(player, currentCard);
            BasicOperations.drawCard(player, currentCard);
        }

        //draw 3 card
        public static void CE12(Player player, List<Card> currentCard)
        {
            BasicOperations.drawCard(player, currentCard);
            BasicOperations.drawCard(player, currentCard);
            BasicOperations.drawCard(player, currentCard);
        }

        //gatling
        public static void CE13(List<Player> victims, List<Card> currentCard, List<Card> removeCard)
        {
            foreach (Player v in victims)
            {
                if (CE06(v, removeCard, currentCard))
                {
                    v.currentHP--;
                }
            }
        }


        //duel
        public static void CE14(Player actor, Player victim)
        {
            //send bang request to victim
            //send bang request to actor
        }

        //indians
        public static void CE15(List<Player> player)
        {
            foreach (Player p in player)
            {
                //send bang request
            }
        }

        //general store
        public static void CE16(List<Player> player, List<Card> currentList)
        {
            List<Card> card = new List<Card>();
            for (int i = 0; i < player.Count; i++)
            {
                card.Add(currentList[i]);
                currentList.RemoveAt(i);
            }
            foreach (Player p in player)
            {
                Card c = BasicOperations.sendPickCardRequest(p, card);
                p.cardsOnHand.Add(c);
                card.Remove(c);
            }
        }

        //saloon
        public static void CE17(Player actor, List<Player> others)
        {
            CE08(actor);
            foreach (Player p in others)
            {
                if (p.currentHP < p.maxHP)
                {
                    p.currentHP++;
                }
            }
        }

        //jail
        public static void CE18(Player player, List<Card> currentCard, List<Card> removeCard, Card card)
        {
            Card c = BasicOperations.checkCard(removeCard, currentCard);
            if (c.suit == 3)
            {
                BasicOperations.unequipCard(player, card);
                removeCard.Add(c);
            }
            else
            {
                BasicOperations.unequipCard(player, card);
                removeCard.Add(c);
                //skip turn
            }
        }

        //dynamite
        public static void CE19(Player player, List<Card> currentCard, List<Card> removeCard, Card card)
        {
            Card c = BasicOperations.checkCard(removeCard, currentCard);
            if (c.suit == 4 && c.range >= 2 && c.range <= 9)
            {
                player.currentHP -= 3;
            }
            else
            {
                BasicOperations.unequipCard(player, card);
                // equip card to next
            }
        }

        //barrel
        public static bool CE20(Player player, List<Card> removeCard, List<Card> currentCard)
        {
            Card c = BasicOperations.checkCard(removeCard, currentCard);
            if (c.suit == 3) {
                return true;
            }
            return false;
        }

        //scope
        public static void CE21(Player victim, Player actor)
        {
            //view other --
        }

        public static void CE22(Player player)
        {
            player.distance++;
        }
    }
}
