namespace Puzzle
{
    /// <summary>
    /// Represents an interface for classes that are intended to randomize some values.
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// When implemented generates a sequence of the numbers and randomizes their order.
        /// </summary>
        int[] GenerateRandomSequence(int length);
    }
}