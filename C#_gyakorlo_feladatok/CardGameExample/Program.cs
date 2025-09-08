using System;

namespace CardGameExample
{

    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager(4, 5, 2);
            gm.PlayGame();
        }
    }
}