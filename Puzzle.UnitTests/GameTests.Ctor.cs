using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Puzzle.Abstractions;


namespace Puzzle.UnitTests
{
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
        public void Ctor_SquareFactoryIsNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var game = new Game(null);
            });
        }
    }
}