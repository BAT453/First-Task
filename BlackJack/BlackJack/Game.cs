namespace BlackJack
{
    class Game
    {
        private Deck _deck;
        private Dealer _dealer;
        private Gamer _gamer;

        public Game()
        {
            _deck = new Deck();
            bool continueGame = true;

            while (continueGame)
            {
                Initial(ref _dealer, ref _gamer);

                View.BeginDesk(_dealer.hand, _gamer.Hand);

                if (!CheckBlackJack(_gamer.Hand))
                {
                    View.GamerStep();
                }

                _gamer.DoGamerGame(ref _deck, Value.maximumAllowableAccountValue);

                if (!CheckResult(_gamer.Hand))
                {
                    View.ShowDealerStep();
                    _dealer.DoDealerGame(ref _deck);
                    _dealer.hand.PrintHand();
                }

                View.ViewResult(GetGameResult(_dealer.hand, _gamer.Hand));
                continueGame = View.NextGame();
            }
        }

        private bool CheckBlackJack(Hand hand)
        {
            return hand.GetScore() == Value.maximumAllowableAccountValue && hand.cards.Count == Value.numberOfCardsOnTheFirstHand;
        }

        private bool CheckResult(Hand hand)
        {
            return (hand.GetScore() > Value.maximumAllowableAccountValue);
        }

        private void Initial(ref Dealer dealer, ref Gamer gamer)
        {
            dealer = new Dealer();
            gamer = new Gamer();

            for (int i = 0; i < Value.numberOfCardsOnTheFirstHand; i++)
            {
                gamer.Hand.HitCard(_deck.GetCard());
                dealer.hand.HitCard(_deck.GetCard());
            }
        }

        private FinalResult GetGameResult(Hand dealer, Hand gamer)
        {
            if (CheckBlackJack(gamer) && !CheckBlackJack(dealer))
            {
                return FinalResult.BlackJack;
            }
            if ((gamer.GetScore() > dealer.GetScore() && gamer.GetScore() < Value.maximumAllowableAccountValue) ||
                (gamer.GetScore() <= Value.maximumAllowableAccountValue && dealer.GetScore() > Value.maximumAllowableAccountValue))
            {
                return FinalResult.Win;
            }
            if (gamer.GetScore() == dealer.GetScore())
            {
                return FinalResult.Draw;
            }
            return FinalResult.Lose;
        }
    }
}
