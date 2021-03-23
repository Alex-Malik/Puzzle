using System;
using Puzzle.Abstractions;

namespace Puzzle.Defaults
{
    /// <summary>
    /// Represents a factory that produces the <see cref="NumberedSquare"/> objects.
    /// </summary>
    public class NumberedSquareFactory : ISquareFactory
    {
        /// <summary>
        /// Creates a <see cref="Square"/> object with given expected (correct) position.
        /// </summary>
        public Square CreateByPosition(int position)
        {
            if (position < 0)
                throw new ArgumentException("Position should be greater or equal to zero.");
            
            return new NumberedSquare(position);
        }
    }
}