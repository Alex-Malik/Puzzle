namespace Puzzle
{
    public interface ISquareFactory
    {
        Square CreateByPosition(int position);
    }
}