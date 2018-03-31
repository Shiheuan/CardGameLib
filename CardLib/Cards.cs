using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CardLib
{
    public class Cards: List<Card>, ICloneable
    {
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        public object Clone()
        {
            Cards clonedCards = new Cards();
            foreach (Card sourceCard in this)
            {
                clonedCards.Add(sourceCard);
            }
            return clonedCards;
        }
    }
}
