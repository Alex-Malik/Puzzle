using System;

namespace Puzzle.Exceptions
{
    /// <summary>
    /// Represents a base class for game errors.
    /// </summary>
    public abstract class GameException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameException"/> class with the given message.
        /// </summary>
        protected GameException(string message) : base(message)
        {
        }
    }
}