using System;

namespace CardGameExample
{
    class GameManager
    {
        Player[] _players;
        CardDeck _deck;
        int _numberOfCardsToDeal;
        int _maxCardsToDiscard;

        public GameManager(int playerCount, int numberOfCardsToDeal, int maxCardsToDiscard)
        {
            _players = new Player[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                _players[i] = new Player(numberOfCardsToDeal);
            }
            _deck = new CardDeck();
            _numberOfCardsToDeal = numberOfCardsToDeal;
            _maxCardsToDiscard = maxCardsToDiscard;
            if (_maxCardsToDiscard > _numberOfCardsToDeal)
            {
                _maxCardsToDiscard = _numberOfCardsToDeal;
            }
        }

        public void PlayGame()
        {
            for (int i = 0; i < _numberOfCardsToDeal; i++)
            {
                foreach (Player player in _players)
                    { player.DrawCardFromDeck(_deck); }
            }

            foreach (Player player in _players)
                { PlayerInteraction(player); }

            DetermineAndAnnounceResult();
        }

        private void PlayerInteraction(Player player)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"Now, you can discard at most {_maxCardsToDiscard} cards from your hand");
            for (int round=0; round < _maxCardsToDiscard; round++)
            {
                Console.Write("Your cards:");
                for (int i = 0; i < player.CardCount; i++)
                {
                    Console.Write($"  {player.GetCard(i).Value}");
                }
                Console.WriteLine();
                bool discarded = ReadIndexAndDiscard(player);
                if (!discarded) { break; }
            }
            Console.Write("Your cards at the end:");
            for (int i = 0; i < player.CardCount; i++)
            {
                Console.Write($"  {player.GetCard(i).Value}");
            }
            Console.WriteLine();
        }

        private bool ReadIndexAndDiscard(Player player)
        {
            bool inputOk = false;
            do
            {
                Console.Write($"Which card do you want to discard? (1-{player.CardCount} or \'X\')  ");
                string answer = Console.ReadLine();
                if (answer == "X") { return false; }
                int index = int.Parse(answer) - 1;
                if (index < 0 || index >= player.CardCount)
                {
                    Console.WriteLine("Invalid index, try again!");
                    inputOk = false;
                }
                else
                {
                    inputOk = true;
                    player.DiscardCardByIndex(index);
                }
            } while (!inputOk);
            return true;
        }

        private void DetermineAndAnnounceResult()
        {
            //...
            Console.WriteLine("-----------------");
            Console.WriteLine("Result determination is TODO... (No rules yet)");
        }
    }
}
