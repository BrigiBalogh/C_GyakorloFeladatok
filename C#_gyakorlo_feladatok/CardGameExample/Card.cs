using System;

namespace CardGameExample
{
    class Card
    {
        public char Suit { get; } // '♠', '♥', '♦', '♣'
        public string Rank { get; } // "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"

        public Card(char suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string Value
        {
            get { return Suit + Rank; }
        }
    }
}
