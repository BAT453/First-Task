using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Deck
    {
        private Stack<Card> _deck;
        private List<int> cardValue;

        public Deck()
        {
            _deck = new Stack<Card>();

            cardValue = new List<int>();
            GetCardValue();

            LinkedList<int> list = new LinkedList<int>();
            for (int i = 1; i <= Value.numberOfCardInTheDeck; i++)
            {
                list.AddFirst(i);
            }
            FillDeck(list);
        }

        private void FillDeck(LinkedList<int> list)
        {
            Random rand = new Random();
            for (int j = 0; j < Value.numberOfCardInTheDeck; j++)
            {
                int i = list.ElementAt(rand.Next(list.Count));
                list.Remove(i);
                CardSuit tempCardSuit = (CardSuit)((i % Value.numberOfSuitsOfTheSameCard) == 0 ? Value.numberOfSuitsOfTheSameCard : i % Value.numberOfSuitsOfTheSameCard);
                CardRank tempCardRunk = (CardRank)((i % Value.numberOfCardsOfTheSameSuit) == 0 ? Value.numberOfCardsOfTheSameSuit : i % Value.numberOfCardsOfTheSameSuit);

                Card card = new Card();
                card.Suit = tempCardSuit;
                card.Rank = tempCardRunk;
                card.Value = cardValue[(int)tempCardRunk];
                _deck.Push(card);
            }
        }

        private void GetCardValue()
        {
            int startCardWeight = 2;
            int beginspesificWeight = 10;
            cardValue.Add(0);
            for (int i = startCardWeight; i <= beginspesificWeight; i++)
            {
                cardValue.Add(startCardWeight++);
            }
            for (int i = beginspesificWeight; i < Value.numberOfCardsOfTheSameSuit; i++)
            {
                cardValue.Add(10);
            }

            cardValue.Add(11);
        }

        public Card GetCard()
        {
            return _deck.Pop();
        }
    }
}


/*
 * public static Dictionary<CardRank, int> cardValue =
    new Dictionary<CardRank, int>()
    {
        { CardRank.Two, 2},
        { CardRank.Three, 3 },
        { CardRank.Four, 4 },
        { CardRank.Five, 5 },
        { CardRank.Six, 6 },
        { CardRank.Seven, 7 },
        { CardRank.Eight, 8 },
        { CardRank.Nine, 9 },
        { CardRank.Ten, 10 },
        { CardRank.Jack, 10  },
        { CardRank.Queen, 10 },
        { CardRank.King, 10  },
        { CardRank.Ace, 11 }
    };
 **/
