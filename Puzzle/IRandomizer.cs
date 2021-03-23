using System;
using System.Linq;

namespace Puzzle
{
    public interface IRandomizer
    {
        int[] GenerateRandomSequence(int length);
    }

    internal class DefaultRandomizer : IRandomizer
    {
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