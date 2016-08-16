using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Gameplay
{
    public static class CharacterSkill
    {
        public static void SkillID1(Player player, List<Card> currentCard)
        {
            if (player.ownCard.Count == 0)
            {
                BasicOperations.drawCard(player, currentCard);
            }
        }
        
        public static void SkillID2(Player player)
        {
            player.distance++;
        }

        public static void SkillID3(Player player, List<Card> currentCard, List<Card> removeCard)
        {
            BasicOperations.drawCard(player, currentCard);
            BasicOperations.drawFromRemoveCard(player, currentCard);
        }

        public static void SkillID4(Player player)
        {
            //Bang as Miss
        }

        public static void SkillID5(Player player, Player actor)
        {
            Card c = BasicOperations.sendPickCardRequest(player, actor.ownCard);
            BasicOperations.drawFromAnother(player, actor, c);
        }

        //return true for checking right
        public static bool SkillID6(Player player, List<Card> currentCard, List<Card> removeCard) 
        {
            if (BasicOperations.checkCard(removeCard, currentCard).suit == 3)
            {
                return true;
            }
            return false;
        }

        public static Card SkillID7(Player player, List<Card> currentCard, List<Card> removeCard)
        {
            List<Card> card = new List<Card>();
            card.Add(BasicOperations.checkCard(removeCard, currentCard));
            card.Add(BasicOperations.checkCard(removeCard, currentCard));
            Card c = BasicOperations.sendPickCardRequest(player, card);
            return c;
        }

        public static void SkillID8(Player player, Player receiver)
        {
            //2 miss to dodge 
        }

        public static void SkillID9(Player player)
        {
            player.hasBang = false;
        }

        public static void SkillID010(Player player, Player receiver)
        {
            Card c = BasicOperations.sendPickCardRequest(player, receiver.ownCard);
            BasicOperations.drawFromAnother(player, receiver, c);
        }

        public static void SkillID11(Player player, List<Card> currentCard)
        {
            BasicOperations.drawCard(player, currentCard);
        }

        public static void SkillID12(Player player, List<Card> currentCard)
        {
            BasicOperations.showCard(currentCard[0]);
            player.ownCard.Add(currentCard[0]);
            if (currentCard[0].suit == 3 || currentCard[0].suit == 2)
            {
                currentCard.RemoveAt(0);
                BasicOperations.drawCard(player, currentCard);
            }
        }

        public static void SkillID13(Player player, List<Card> currentCard, List<Card> removeCard)
        {
            List<Card> card = new List<Card>();
            card.Add(currentCard[0]);
            card.Add(currentCard[1]);
            card.Add(currentCard[2]);
            Card c = BasicOperations.sendPickCardRequest(player, card);
            foreach (Card ca in card)
            {
                BasicOperations.drawCard(player, currentCard);
                if (ca.Equals(c))
                {
                    BasicOperations.removeCard(removeCard, player, ca);
                }
            }
        }

        public static void SkillID14(Player player)
        {
            player.range++; // not sure
        }

        public static void SkillID15(Player player, List<Card> removeCard)
        {
            if (player.currentHP < player.maxHP)
            {
                BasicOperations.removeCard(removeCard, player, BasicOperations.sendPickCardRequest(player, player.ownCard));
                BasicOperations.removeCard(removeCard, player, BasicOperations.sendPickCardRequest(player, player.ownCard));
                player.currentHP++;
            }
        }

        public static void SkillID16(Player player)
        {
            //if event death occur --> return a death 
            //foreach card in death.ownCard()
            //BasicOperations.drawFromAnother(player, death, card)
        }
    }
}
