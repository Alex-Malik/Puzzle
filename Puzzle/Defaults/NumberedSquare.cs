using Puzzle.Abstractions;

namespace Puzzle.Defaults
{
    /// <summary>
    /// Represents a square instance that uses a number as a value to display itself.
    /// </summary>
    public class NumberedSquare : Square
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberedSquare"/> class.
        /// </summary>
        protected internal NumberedSquare(int correctPosition) : base(correctPosition)
        {
            DisplayNumber = (correctPosition + 1).ToString();
        }

        /// <summary>
        /// Gets the number that should be displayed for that square.
        /// </summary>
        public string DisplayNumber { get; }

        /// <summary>
        /// Overrides ToString() to show a DisplayNumber.
        /// </summary>
        public override string ToString() => DisplayNumber;
    }
}