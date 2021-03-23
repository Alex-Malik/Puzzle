using System;

namespace Puzzle
{
    class NumberedSquareFactory : ISquareFactory
    {
        private const int PositionMin = 0;
        private const int PositionMax = 15;
        private const string PositionOutOfRange = "The correct position of the square should be between 0 and 15 inclusively.";

        public Square CreateByPosition(int position)
        {
            if (position < PositionMin || position > PositionMax)
                throw new ArgumentOutOfRangeException(nameof(position), PositionOutOfRange);

            return new NumberedSquare(position);
        }
    }
}