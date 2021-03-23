using System;
using NUnit.Framework;
using Puzzle.Defaults;

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
        public void CreateByPosition_PositionIsLessThenZero_ThrowsArgumentException()
        {
            var squareFactory = new NumberedSquareFactory();

            Assert.Throws<ArgumentException>(() => squareFactory.CreateByPosition(-1));
            Assert.Throws<ArgumentException>(() => squareFactory.CreateByPosition(-13));
        }
    }
}