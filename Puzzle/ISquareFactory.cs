namespace Puzzle
{
    /// <summary>
    /// Represents a factory which is when implemented intended to produce <see cref="Square"/>s.
    /// </summary>
    public interface ISquareFactory
    {
        /// <summary>
        /// When implemented creates a <see cref="Square"/> object.
        /// </summary>
        Square CreateByPosition(int position);
    }
}