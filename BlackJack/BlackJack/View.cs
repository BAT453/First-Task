using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public static class View
    {
        public static void BeginDesk(Hand dealer, Hand gamer)
        {
            Console.WriteLine("Dealer:");
            Console.WriteLine("Hidden card");
            Hand temp = new Hand();
            temp.HitCard(dealer.cards.Last());
            ShowCard(temp.cards, temp.GetScore());
            Console.WriteLine("\nGamer:");
            ShowCard(gamer.cards, gamer.GetScore());
        }

        public static bool NextGame()
        {
            Console.WriteLine("Do you want continue? (y/n)");
            string res = Console.ReadLine();
            bool continueGame = (res == "y");
            Console.WriteLine(continueGame ? "\n******NEXT GAME******\n" : "");
            return continueGame;
        }

        public static void SelectYourChoise()
        {
            Console.WriteLine("HIT(press h) or STAND(press any button)?");
        }

        public static void ViewResult(FinalResult s)
        {
            Console.WriteLine("\nYour resuls of this game: {0}", s.ToString().ToUpper());
        }

        public static void ShowCard(List<Card> cards, int score)
        {
            foreach (Card item in cards)
            {
                PrintCard(item);
            }
            Console.WriteLine("Score: {0}", score);
        }

        public static void PrintCard(Card card)
        {
            Console.Write("{0} {1}\n",card.Suit , card.Rank);
        }

        public static void GamerStep()
        {
            Console.WriteLine("\nYour step:");
        }

        public static void ShowDealerStep()
        {
            Console.WriteLine("\nDealer step:");
        }

        public static bool GetAnswer()
        {
            string ans = Console.ReadLine();
            return (ans == "h" || ans == "H");
        }
    }
}
