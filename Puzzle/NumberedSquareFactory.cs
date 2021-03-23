using System;

namespace Puzzle
{
    /// <summary>
    /// Represents a factory that produces the <see cref="NumberedSquare"/> objects.
    /// </summary>
    public class NumberedSquareFactory : ISquareFactory
    {
        private const int PositionMin = 0;
        private const int PositionMax = 15;
        private const string PositionOutOfRange = "The correct position of the square should be between 0 and 15 inclusively.";

        /// <summary>
        /// Creates a <see cref="Square"/> object with given expected (correct) position.
        /// </summary>
        public Square CreateByPosition(int position)
        {
            if (position < PositionMin || position > PositionMax)
                throw new ArgumentOutOfRangeException(nameof(position), PositionOutOfRange);

            return new NumberedSquare(position);
        }
    }
}