using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace CardClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();

            /* test Shuffle().
             */
            //myDeck.Shuffle();
            //for (int i = 0; i < Deck.CardsNum; i++)
            //{
            //    Card tempCard = myDeck.GetCard(i);
            //    Console.Write(tempCard.ToString());
            //    if (i != Deck.CardsNum - 1)
            //        Console.Write(", ");
            //    else
            //        Console.WriteLine();
            //}

            /* test Clone().
             */
            Deck myClonedDeck = (Deck)myDeck.Clone();
            Console.WriteLine($"The first card in the original deck is: {myDeck.GetCard(0)}");
            Console.WriteLine($"The first card in the cloned deck is: {myClonedDeck.GetCard(0)}");
            myDeck.Shuffle();
            Console.WriteLine("The original deck shuffled.");
            Console.WriteLine($"The first card in the original deck is: {myDeck.GetCard(0)}");
            Console.WriteLine($"The first card in the cloned deck is: {myClonedDeck.GetCard(0)}");

            /* end
             */
            Console.ReadKey();
        }
    }
}
