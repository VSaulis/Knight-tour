using System;

namespace KnightTour
{
    public class Program {

        static void Main(string[] args)
        {
            int size, i, j;
            Console.WriteLine("Please enter size of chessboard:");
            string input = Console.ReadLine();
            Int32.TryParse(input, out size);
            Console.WriteLine("Please enter starting position i:");
            input = Console.ReadLine();
            Int32.TryParse(input, out i);
            Console.WriteLine("Please enter starting position j:");
            input = Console.ReadLine();
            Int32.TryParse(input, out j);

            Game game = new Game();
            game.InitGame(size);
            game.Start(i - 1, j - 1);
            Console.Read();
        }
    }
}
