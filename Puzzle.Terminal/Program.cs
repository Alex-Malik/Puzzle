using System;
using System.Collections.Generic;
using System.Linq;
using Puzzle.Abstractions;
using Puzzle.Defaults;

namespace Puzzle.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            // Game dependencies and parameters.
            var factory = new NumberedSquareFactory();

            var game = new Game(factory);

            game.Start();

            do
            {
                Console.Clear();
                Console.WriteLine("Use W, A, S, D or arrows to move the numbers.");
                Console.WriteLine("Use R to restart the game. Press Q to quit.");
                Console.WriteLine("Good luck :)");
                
                DisplayBoard(game.Board);
                
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q) 
                    return;
                
                if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
                    game.SlideUp();
                else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
                    game.SlideDown();
                else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
                    game.SlideLeft();
                else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                    game.SlideRight();
                else if (input.Key == ConsoleKey.R)
                    game.Restart();
                else
                    continue;

                if (!game.IsFinished) continue;
                Console.WriteLine("Congratulations! You did everything right.");
                return;
            } while (true);
        }

        static void DisplayBoard(IEnumerable<Square> board)
        {
            if (board != null && !board.Any()) return;
            var boardArray = board.ToArray();

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("  ");
                for (int j = 0; j < 4; j++)
                {
                    var square = boardArray[i * 4 + j] as NumberedSquare;
                    Console.Write($"{square?.DisplayNumber.PadLeft(2) ?? "  "} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}