using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Puzzle.UnitTests
{
    /// <summary>
    /// Represents class that performs a unit testing of the <see cref="Game"/> class.
    /// </summary>
    public partial class GameTests
    {
        [Test]
        public void Ctor_AsUsual()
        {
            var game = new Game(Mock.Of<ISquareFactory>());
            
            Assert.IsEmpty(game.Board);
            Assert.IsFalse(game.IsFinished);
        }
        
        [Test]
        public void Start_AsUsual_CreatesBoardWithSquares()
        {
            var game = new Game(MockSquareFactory().Object);
            
            game.Start();
            
            Assert.IsNotNull(game.Board);
            Assert.IsNotEmpty(game.Board);
            Assert.IsFalse(game.IsFinished);
        }
        
        [Test]
        public void Start_AsUsual_UsesGivenFactory()
        {
            var mockedFactory = MockSquareFactory();
            var game = new Game(mockedFactory.Object);
            
            game.Start();
            
            mockedFactory.Verify(squareFactory => squareFactory.CreateByPosition(It.IsAny<int>()));
        }
        
        [Test]
        public void Start_AsUsual_Generates15SquaresAndOneEmpty()
        {
            var game = new Game(MockSquareFactory().Object);
            
            game.Start();
            
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
            Assert.IsTrue(game.Board.Count(square => square == null) == 1);
        }

        [Test]
        public void Start_AlreadyStarted_ThrowsAnException()
        {
            var game = new Game(MockSquareFactory().Object);
            
            game.Start();

            Assert.Throws<Exception>(() => game.Start());
        }

        private Mock<IRandomizer> MockRandomizer(params int[] positions)
        {
            var mockedRandomizer = new Mock<IRandomizer>();
            mockedRandomizer
                .Setup(randomizer => randomizer.GenerateRandomSequence(It.IsAny<int>()))
                .Returns<int>(length => positions.ToArray());

            return mockedRandomizer;
        }

        private Mock<ISquareFactory> MockSquareFactory()
        {
            var mockedSquareFactory = new Mock<ISquareFactory>();
            mockedSquareFactory
                .Setup(squareFactory => squareFactory.CreateByPosition(It.IsAny<int>()))
                .Returns<int>(targetPosition => new FakeSquare(targetPosition));
            
            return mockedSquareFactory;
        }
    }

    class FakeSquare : Square
    {
        public FakeSquare(int correctPosition) : base(correctPosition)
        {
        }
        
        /// <summary>
        /// Overrides ToString() to show a DisplayNumber.
        /// </summary>
        public override string ToString() => CorrectPosition.ToString();
    }
}