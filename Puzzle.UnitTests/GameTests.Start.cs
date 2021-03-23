using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Puzzle.UnitTests
{
    public partial class GameTests
    {
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
    }
}