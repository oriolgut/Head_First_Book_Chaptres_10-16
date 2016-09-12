using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishGameWA
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();
        public int Count { get { return cards.Count; } }

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Values)value, (Suits)suit));
        }
        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal()
        {
            return Deal(0);
        }

        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(c => random.Next()).ToList();
        }

        public Deck PullOutValues(Values value)
        {
            Deck decktoReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    decktoReturn.Add(Deal(i));
            return decktoReturn;
        }

        public IEnumerable<string> GetCardNames()
        {
            string[] cardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
                cardNames[i] = cards[i].Name;
            return cardNames;
        }

        public void SortBySuit()
        {
            cards.Sort(new CardComparer_bySuit());
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }

        public bool ContainsValue (Values value)
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }

        public bool HasBook(Values value)
        {
            int numberofCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    numberofCards++;
            if (numberofCards == 4)
                return true;
            else
                return false; 
        }
    }
}
