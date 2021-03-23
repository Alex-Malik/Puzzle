using System;
using System.Linq;
using NUnit.Framework;

namespace Puzzle.UnitTests
{
    public partial class GameTests
    {
        [Test]
        public void SlideLeft_GameNotStarted_ThrowsAnException()
        {
            var game = new Game(MockSquareFactory().Object);

            Assert.Throws<Exception>(() => game.SlideLeft());
        }
        
        [Test]
        public void SlideLeft_HasSpaceToSlide_SlidesLeft()
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
            game.SlideLeft();
            
            Assert.IsNull(game.Board.ToArray()[6]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideLeft_HasNoSpaceToSlide_DoesNothing()
        {
            var initialSequence = new[]
            {
                0,  1,  2,  3,
                4,  5,  6, 
                8,  9,  10, 11,
                12, 13, 14, 15, 7 // - the last index is the empty square position
            };

            var game = new Game(
                MockSquareFactory().Object,
                MockRandomizer(initialSequence).Object);
            
            game.Start();
            game.SlideLeft();
            
            Assert.IsNull(game.Board.ToArray()[7]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideLeft_LastSlideToWon_GameWon()
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
            game.SlideRight();
            game.SlideLeft();
            
            Assert.IsTrue(game.IsFinished);
        }
    }
}