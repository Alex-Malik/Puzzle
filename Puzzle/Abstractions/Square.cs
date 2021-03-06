namespace Puzzle.Abstractions
{
    /// <summary>
    /// Represents the base class for the squares used in the game.
    /// </summary>
    public abstract class Square
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with given correct position on the board. 
        /// </summary>
        protected Square(int correctPosition)
        {
            CorrectPosition = correctPosition;
        }

        /// <summary>
        /// Gets the correct position of the square. That is the place where the
        /// square should appear to successfully finish the game.
        /// </summary>
        public int CorrectPosition { get; }
    }
}