namespace Puzzle.Exceptions
{
    /// <summary>
    /// Represents an error that occurs when the user tries to execute any action
    /// that requires the game to be started.
    /// </summary>
    public class GameNotStartedException : GameException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameNotStartedException"/> class.
        /// </summary>
        public GameNotStartedException() : base("Game should be started first.")
        {
        }
    }
}