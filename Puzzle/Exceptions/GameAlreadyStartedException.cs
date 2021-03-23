namespace Puzzle.Exceptions
{
    /// <summary>
    /// Represents an error that occurs when the user tries to start the game that is already started. 
    /// </summary>
    public class GameAlreadyStartedException : GameException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameAlreadyStartedException"/> class.
        /// </summary>
        internal GameAlreadyStartedException() : base("Game already started and cannot be started again.")
        {
        }
    }
}