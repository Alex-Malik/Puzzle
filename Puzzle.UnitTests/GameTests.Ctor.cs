using System;
using System.Linq;
using Moq;
using NUnit.Framework;


namespace Puzzle.UnitTests
{
    public class GameTests_Ctor
    {
        [Test]
        public void Ctor_AsUsual()
        {
            var game = new Game(Mock.Of<ISquareFactory>());
            
            Assert.IsEmpty(game.Board);
            Assert.IsFalse(game.IsFinished);
        }

        [Test]
        public void Ctor_SquareFactoryIsNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var game = new Game(null);
            });
        }
    }
}