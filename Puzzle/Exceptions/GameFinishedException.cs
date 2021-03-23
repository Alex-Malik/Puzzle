namespace Puzzle.Exceptions
{
    /// <summary>
    /// Represents an error that occurs when the user tries to execute any action
    /// that requires the game to be not finished.
    /// </summary>
    public class GameFinishedException : GameException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameFinishedException"/> class.
        /// </summary>
        public GameFinishedException() : base("Game finished. Start a new one to make slides.")
        {
        }
    }
}