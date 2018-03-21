using System.Collections.Generic;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> cards;
        public int Result { get; set; }

        public Hand()
        {
            cards = new List<Card>();
        }

        public void HitCard(Card card)
        {
            cards.Add(card);
        }

        public int GetScore()
        {
            int score = Value.beginScore;
            bool aceInHand = false;

            foreach (Card card in cards)
            {
                aceInHand = (card.Rank == CardRank.Ace);
                score += card.Value;
                score =
                    (aceInHand && score > Value.maximumAllowableAccountValue) ?
                    score - Value.differenceBetweenSoftAndUsualAce :
                    score;
            }

            return score;
        }

        public void PrintHand()
        {
            View.ShowCard(cards, GetScore());
        }
    }
}
