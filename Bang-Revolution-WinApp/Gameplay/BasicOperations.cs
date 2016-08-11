using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Gameplay
{
    public class BasicOperations
    {
        public void drawCard(Player player, List<Card> currentCard)
        {
            player.ownCard.Add(currentCard[0]);
            currentCard.RemoveAt(0);
        }

        public List<Card> shufferCard(List<Card> shuffer)
        {
            List<Card> newList = new List<Card>();
            List<int> check = new List<int>();
            foreach (Card card in shuffer)
            {
                Random rd = new Random();
                int i = rd.Next(0, shuffer.Count);
                while (check.Contains(i)) {
                    i = rd.Next(0, shuffer.Count);
                } 
                newList.Add(shuffer[i]);
                check.Add(i);
            }
            return newList;
        }

        

    }
}
