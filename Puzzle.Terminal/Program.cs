using System;

namespace Puzzle.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Game dependencies and parameters.
            var factory = new NumberedSquareFactory();

            var game = new Game(factory);

            game.Start();

            do
            {
                DisplayBoard(game._board);
                
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q) break;
                
                if (input.Key == ConsoleKey.W)
                    game.SlideUp();
                else if (input.Key == ConsoleKey.S)
                    game.SlideDown();
                else if (input.Key == ConsoleKey.A)
                    game.SlideLeft();
                else if (input.Key == ConsoleKey.D)
                    game.SlideRight();
                else
                    continue;
            } while (true);
        }

        static void DisplayBoard(Square[] board)
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var square = board[i * 4 + j] as NumberedSquare;
                    Console.Write($"{square?.DisplayNumber.PadLeft(2) ?? "  "} ");
                }

                Console.WriteLine();
            }
        }
    }
}