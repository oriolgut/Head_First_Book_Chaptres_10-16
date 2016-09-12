using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishGameWA
{
    class CardComparer_bySuit : IComparer<Card>
    {
        public int Compare(Card cardOne, Card cardTwo)
        {
            if (cardOne.Suit < cardTwo.Suit)
            {
                return -1;
            }
            if (cardOne.Suit > cardTwo.Suit)
            {
                return 1;
            }
            if (cardOne.Value < cardTwo.Value)
            {
                return -1;      
            }
            if(cardOne.Value > cardTwo.Value)
            {
                return 1;
            }
            return 0;
        }
    }
}
