using System;

namespace CardGameExample
{
    class Player
    {
        Card[] _cardsInHand;
        public int CardCount { get; private set; }

        public Player(int maxCardCount)
        {
            _cardsInHand = new Card[maxCardCount];
            for (int i=0; i<maxCardCount; i++)
                { _cardsInHand[i] = null; }
            int CardCount = 0;
        }

        public void DrawCardFromDeck(CardDeck deck)
        {
            if (CardCount == _cardsInHand.Length) { return; }
            else
            {
                Card newCard = deck.DrawTopCard();
                if (newCard != null)
                {
                    _cardsInHand[CardCount] = newCard;
                    CardCount++;
                }
            }
        }

        public Card GetCard(int index)
        {
            if (index < 0 || index >= CardCount) 
                { return null; }
            return _cardsInHand[index];
        }

        public void DiscardCardByIndex(int index)
        {
            if (index < 0 || index >= CardCount)
                { return; }
            for (int i=index; i<CardCount-1; i++)
                { _cardsInHand[i] = _cardsInHand[i + 1]; }
            _cardsInHand[CardCount - 1] = null;
            CardCount--;
        }
    }
}
