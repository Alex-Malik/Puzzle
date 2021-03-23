using System;
using System.Linq;
using NUnit.Framework;

namespace Puzzle.UnitTests
{
    public partial class GameTests
    {
        [Test]
        public void SlideDown_GameNotStarted_ThrowsAnException()
        {
            var game = new Game(MockSquareFactory().Object);

            Assert.Throws<Exception>(() => game.SlideDown());
        }
        
        [Test]
        public void SlideDown_HasSpaceToSlide_SlidesUp()
        {
            var initialSequence = new[]
            {
                0,  1,  2,  3,
                4,      6,  7,
                8,  9,  10, 11,
                12, 13, 14, 15, 5 // - the last index is the empty square position
            };

            var game = new Game(
                MockSquareFactory().Object,
                MockRandomizer(initialSequence).Object);
            
            game.Start();
            game.SlideDown();
            
            Assert.IsNull(game.Board.ToArray()[1]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideDown_HasNoSpaceToSlide_DoesNothing()
        {
            var initialSequence = new[]
            {
                0,      2,  3,
                4,  5,  6,  7,
                8,  9,  10, 11,
                12, 13, 14, 15, 1 // - the last index is the empty square position
            };

            var game = new Game(
                MockSquareFactory().Object,
                MockRandomizer(initialSequence).Object);
            
            game.Start();
            game.SlideDown();
            
            Assert.IsNull(game.Board.ToArray()[1]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideDown_LastSlideToWon_GameWon()
        {
            var initialSequence = new[]
            {
                0,  1,  2,  3,
                4,  5,  6,  7,
                8,  9,  10, 11,
                12, 13, 14,     15 // - the last index is the empty square position
            };

            var game = new Game(
                MockSquareFactory().Object,
                MockRandomizer(initialSequence).Object);
            
            game.Start();
            game.SlideDown();
            game.SlideUp();
            game.SlideDown();
            
            Assert.IsTrue(game.IsFinished);
        }
    }
}