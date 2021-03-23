namespace Puzzle
{
    /// <summary>
    /// Represents a factory which is when implemented intended to produce <see cref="Square"/>s.
    /// It should be used to generate different types of squares e.g. with numbers or images.
    /// </summary>
    public interface ISquareFactory
    {
        /// <summary>
        /// When implemented creates a <see cref="Square"/> object.
        /// </summary>
        Square CreateByPosition(int position);
    }
}