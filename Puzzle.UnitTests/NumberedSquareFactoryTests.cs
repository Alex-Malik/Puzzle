using System;
using NUnit.Framework;

namespace Puzzle.UnitTests
{
    public class NumberedSquareFactoryTests
    {
        [Test]
        public void CreateByPosition_AsExpected_ReturnsNewNumberedSquare()
        {
            var squareFactory = new NumberedSquareFactory();

            var square = squareFactory.CreateByPosition(0);
            Assert.IsNotNull(square);
            Assert.IsInstanceOf<NumberedSquare>(square);
            
            square = squareFactory.CreateByPosition(7);
            Assert.IsNotNull(square);
            Assert.IsInstanceOf<NumberedSquare>(square);
            
            square = squareFactory.CreateByPosition(13);
            Assert.IsNotNull(square);
            Assert.IsInstanceOf<NumberedSquare>(square);
            
            square = squareFactory.CreateByPosition(15);
            Assert.IsNotNull(square);
            Assert.IsInstanceOf<NumberedSquare>(square);
        }

        [Test]
        public void CreateByPosition_PositionIsOutOfRange_ThrowsOutOfRangeException()
        {
            var squareFactory = new NumberedSquareFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => squareFactory.CreateByPosition(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => squareFactory.CreateByPosition(-13));
            Assert.Throws<ArgumentOutOfRangeException>(() => squareFactory.CreateByPosition(16));
            Assert.Throws<ArgumentOutOfRangeException>(() => squareFactory.CreateByPosition(100));
        }
    }
}