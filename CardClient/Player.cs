using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace CardClient
{
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player() { }
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        public bool HasWon()
        {
            bool Won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 0; i < PlayHand.Count; i++)
            {
                Won &= PlayHand[i].suit == match;
            }
            return Won;
        }
    }
}
