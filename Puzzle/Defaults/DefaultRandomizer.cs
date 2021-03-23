using System;
using System.Linq;
using Puzzle.Abstractions;

namespace Puzzle.Defaults
{
    /// <summary>
    /// Represents a default mechanism to randomize a sequence of the sequential numbers.
    /// </summary>
    internal class DefaultRandomizer : IRandomizer
    {
        /// <summary>
        /// Generates a sequence of the numbers and randomizes their order.
        /// </summary>
        public int[] GenerateRandomSequence(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException();
            
            var random = new Random();
            var randomSequence = Enumerable.Range(0, length).OrderBy(_ => random.Next());

            return randomSequence.ToArray();
        }
    }
}