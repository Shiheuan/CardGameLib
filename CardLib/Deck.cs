using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class Deck
    {
        private Card[] cards;
        public const int CardsNum = 52;
        public Deck()
        {
            cards = new Card[CardsNum];
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards[13 * suitVal + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= CardsNum-1)
            {
                return cards[cardNum];
            }
            else
            {
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 to 51."));
            }
        }

        public void Shuffle()
        {
            Card[] newDeck = new Card[CardsNum];
            bool[] assigned = new bool[CardsNum];
            Random sourceGen = new Random();
            for (int i = 0; i < CardsNum; i++)
            {
                int deskCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    deskCard = sourceGen.Next(CardsNum);
                    if (assigned[deskCard] == false)
                    {
                        foundCard = true;
                    }
                }
                assigned[deskCard] = true;
                newDeck[deskCard] = cards[i];
            }
            newDeck.CopyTo(cards, 0);
        }
    }
}