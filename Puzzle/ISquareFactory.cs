namespace Puzzle
{
    interface ISquareFactory
    {
        Square CreateByPosition(int position);
    }
}