using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class Deck : ICloneable
    {
        // private Card[] cards;
        private Cards cards = new Cards();
        public const int CardsNum = 52;
        public Deck()
        {
            // cards = new Card[CardsNum];
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    // cards[13 * suitVal + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        // rules in this Deck
        public Deck(bool isAceHigh): this()
        {
            Card.isAceHigh = isAceHigh;
        }

        public Deck(bool useTrumps, Suit trump): this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        // rules in this Deck <end>

        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= CardsNum - 1)
            {
                return cards[cardNum];
            }
            else
            {
                //throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 to 51."));
                throw new CardOutOfRangeException(cards.Clone() as Cards);
            }
        }

        public void Shuffle()
        {
            //Card[] newDeck = new Card[CardsNum];
            Cards newDeck = new Cards();
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
                //newDeck[deskCard] = cards[i];
                newDeck.Add(cards[deskCard]);
            }
            newDeck.CopyTo(cards);
        }

        public object Clone()
        {
            Deck clonedDeck = new Deck((Cards)cards.Clone());
            return clonedDeck;
        }
    }
}