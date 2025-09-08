using System;

namespace CardGameExample
{
    class CardDeck
    {
        Card[] _cards;
        public int RemainingCards { get; private set; }

        public CardDeck(bool shuffle = true)
        {
            _cards = new Card[52];
            char[] suits = { '♠', '♥', '♦', '♣' };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int cardId = 0;
            foreach (char suit in suits)
            {
                foreach (string rank in ranks)
                {
                    _cards[cardId] = new Card(suit, rank);
                    cardId++;
                }
            }
            RemainingCards = 52;
            if (shuffle) ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            for (int i=0; i< RemainingCards; i++)
            {
                int cardIndexToSwapHere = random.Next(i, RemainingCards);
                Card temp = _cards[cardIndexToSwapHere];
                _cards[cardIndexToSwapHere] = _cards[i];
                _cards[i] = temp;
            }
        }

        public Card DrawTopCard()
        {
            if (RemainingCards == 0) { return null; }
            Card cardToReturn = _cards[RemainingCards - 1];
            _cards[RemainingCards - 1] = null;
            RemainingCards--;
            return cardToReturn;
        }

        public bool IsEmpty()
        {
            return RemainingCards == 0;
        }
    }
}
