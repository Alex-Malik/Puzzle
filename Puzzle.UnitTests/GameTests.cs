using System.Linq;
using Moq;
using Puzzle.Abstractions;

namespace Puzzle.UnitTests
{
    /// <summary>
    /// Represents class that performs a unit testing of the <see cref="Game"/> class.
    /// </summary>
    public partial class GameTests
    {
        // This part of this partial class contains all private methods
        // that are used by test methods in other parts of the class.
        
        /// <summary>
        /// Mocks randomizer to control the order of squares.
        /// </summary>
        private Mock<IRandomizer> MockRandomizer(params int[] positions)
        {
            var mockedRandomizer = new Mock<IRandomizer>();
            mockedRandomizer
                .Setup(randomizer => randomizer.GenerateRandomSequence(It.IsAny<int>()))
                .Returns<int>(length => positions.ToArray());

            return mockedRandomizer;
        }

        /// <summary>
        /// Mocks square factory to produce fake square objects.
        /// </summary>
        private Mock<ISquareFactory> MockSquareFactory()
        {
            var mockedSquareFactory = new Mock<ISquareFactory>();
            mockedSquareFactory
                .Setup(squareFactory => squareFactory.CreateByPosition(It.IsAny<int>()))
                .Returns<int>(targetPosition => new FakeSquare(targetPosition));
            
            return mockedSquareFactory;
        }
        
        /// <summary>
        /// Represents a Square class implementation that is used by unit tests.
        /// </summary>
        private class FakeSquare : Square
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FakeSquare"/> class.
            /// </summary>
            public FakeSquare(int correctPosition) : base(correctPosition) { }
        
            /// <summary>
            /// Overrides ToString() to show a DisplayNumber.
            /// </summary>
            public override string ToString() => CorrectPosition.ToString();
        }
    }
}