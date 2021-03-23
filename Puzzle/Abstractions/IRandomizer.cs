namespace Puzzle.Abstractions
{
    /// <summary>
    /// Represents an interface for classes that are intended to randomize some values.
    /// Could be used to implement different difficulty levels controlling the sequence.
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// When implemented generates a sequence of the numbers and randomizes their order.
        /// </summary>
        int[] GenerateRandomSequence(int length);
    }
}