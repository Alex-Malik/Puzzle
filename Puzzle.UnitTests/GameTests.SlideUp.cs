using System;
using System.Linq;
using NUnit.Framework;
using Puzzle.Exceptions;

namespace Puzzle.UnitTests
{
    public partial class GameTests
    {
        [Test]
        public void SlideUp_GameNotStarted_ThrowsAnException()
        {
            var game = new Game(MockSquareFactory().Object);

            Assert.Throws<GameNotStartedException>(() => game.SlideUp());
        }
        
        [Test]
        public void SlideUp_HasSpaceToSlide_SlidesUp()
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
            game.SlideUp();
            
            Assert.IsNull(game.Board.ToArray()[9]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideUp_HasNoSpaceToSlide_DoesNothing()
        {
            var initialSequence = new[]
            {
                0,  1,  2,  3,
                4,  5,  6,  7,
                8,  9,  10, 11,
                12,     14, 15, 13 // - the last index is the empty square position
            };

            var game = new Game(
                MockSquareFactory().Object,
                MockRandomizer(initialSequence).Object);
            
            game.Start();
            game.SlideUp();
            
            Assert.IsNull(game.Board.ToArray()[13]);
            Assert.IsTrue(game.Board.Count(square => square != null) == 15);
        }
        
        [Test]
        public void SlideUp_LastSlideToWon_GameWon()
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
            
            Assert.IsTrue(game.IsFinished);
        }
    }
}