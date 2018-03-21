namespace BlackJack
{
    class Gamer
    {
        public Hand Hand { get; set; }

        public Gamer()
        {
            Hand = new Hand();
        }

        public void DoGamerGame(ref Deck deck, int blackJackSum)
        {
            bool stand = false;
            while (!stand)
            {
                if (Hand.GetScore() < blackJackSum)
                {
                    View.SelectYourChoise();
                    bool ans = View.GetAnswer();
                    if (ans)
                    {
                        Hand.HitCard(deck.GetCard());
                        stand = Hand.GetScore() > blackJackSum;
                        Hand.PrintHand();
                    }
                    if (!ans)
                    {
                        stand = true;
                    }
                    continue;
                }
                stand = true;
            }
        }
    }
}
