namespace BlackJack
{
    class Dealer
    {
        public Hand hand;

        public Dealer ()
        {
            hand = new Hand();
        }

        public void DoDealerGame(ref Deck deck)
        {
            while (hand.GetScore() < Value.minimumDealerAccount)
            {
                hand.HitCard(deck.GetCard());
            }
        }
    }
}
