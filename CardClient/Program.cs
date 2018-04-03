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
            //Deck myClonedDeck = (Deck)myDeck.Clone();
            //Console.WriteLine($"The first card in the original deck is: {myDeck.GetCard(0)}");
            //Console.WriteLine($"The first card in the cloned deck is: {myClonedDeck.GetCard(0)}");
            //myDeck.Shuffle();
            //Console.WriteLine("The original deck shuffled.");
            //Console.WriteLine($"The first card in the original deck is: {myDeck.GetCard(0)}");
            //Console.WriteLine($"The first card in the cloned deck is: {myClonedDeck.GetCard(0)}");

            /* test operator overloading
             */
            //Card.isAceHigh = true;
            //Console.WriteLine("Ace is high!");
            //Card.useTrumps = true;
            //Card.trump = Suit.Club;
            //Console.WriteLine("Spade is trumps.");
            //Card card1, card2, card3, card4, card5;
            //card1 = new Card(Suit.Club, Rank.Five);
            //card2 = new Card(Suit.Club, Rank.Five);
            //card3 = new Card(Suit.Club, Rank.Ace);
            //card4 = new Card(Suit.Heart, Rank.Ten);
            //card5 = new Card(Suit.Diamond, Rank.Ace);
            //Console.WriteLine($"{card1.ToString()} == {card2.ToString()} ? { card1 == card2}");
            //Console.WriteLine($"{card1.ToString()} != {card3.ToString()} ? {card1 != card3}");
            //Console.WriteLine($"{card1.ToString()}.Equals({card4.ToString()}) ? " +
            //    $" {card1.Equals(card4)}");
            //Console.WriteLine($"Card.Equals({card3.ToString()}, {card4.ToString()}) ? " +
            //    $" {Card.Equals(card3, card4)}");
            //Console.WriteLine($"{card1.ToString()} > {card2.ToString()} ? {card1 > card2}");
            //Console.WriteLine($"{card1.ToString()} <= {card3.ToString()} ? {card1 <= card3}");
            //Console.WriteLine($"{card1.ToString()} > {card4.ToString()} ? {card1 > card4}");
            //Console.WriteLine($"{card4.ToString()} > {card1.ToString()} ? {card4 > card1}");
            //Console.WriteLine($"{card5.ToString()} > {card4.ToString()} ? {card5 > card4}");
            //Console.WriteLine($"{card4.ToString()} > {card5.ToString()} ? {card4 > card5}");

            /* test exception class
             */
            //Deck deck1 = new Deck();
            //try
            //{
            //    Card myCard = deck1.GetCard(60);
            //}
            //catch (CardOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.DeckContents[0]);
            //}

            /* test the first card game
             */
            // Display introduction.
            Console.WriteLine("BenjaminCards: a new and exciting card game.");
            Console.WriteLine("To win you must have 7 cards of the same suit in your hand.");
            Console.WriteLine();
            // Prompt for number of players.
            bool inputOK = false;
            int choice = -1;
            do
            {
                Console.WriteLine("How many players (2-7)?");
                string input = Console.ReadLine();
                try
                {
                    // Attempt to convert input into a valid number of players.
                    choice = Convert.ToInt32(input);
                    if ((choice >= 2) && (choice <= 7))
                    {
                        inputOK = true;
                    }
                }
                catch
                {
                    // Ignore failed conversions, just continue prompting.
                }
            } while (inputOK == false);
            // Initialize array of Player objects.
            Player[] players = new Player[choice];
            // Get player names.
            for (int p = 0; p < players.Length; p++)
            {
                Console.WriteLine($"Player {p + 1}, enter your name:");
                string playerName = Console.ReadLine();
                if (playerName == "") { playerName = $"Player {p + 1}"; }
                players[p] = new Player(playerName);
            }
            // Start game.
            GameManager newGame = new GameManager();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();
            // Display winning player.
            Console.WriteLine($"{players[whoWon].Name} has won the game.");
            /* end
             */
            Console.ReadKey();
        }
    }
}
