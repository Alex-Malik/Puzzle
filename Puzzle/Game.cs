using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    /// <summary>
    /// Represent the game logic with all game mechanics.
    /// </summary>
    public class Game
    {
        // Dependencies.
        private readonly ISquareFactory _squareFactory;
        private readonly IRandomizer _randomizer;

        // Game settings.
        private readonly int _boardSize;
        private readonly int _verticalSlideOffset;
        private readonly int _horizontalSlideOffset;

        // Game variables.
        private Square[] _board;
        private int _emptySquarePosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class. If no arguments provided the default values will be used.
        /// </summary>
        public Game(ISquareFactory squareFactory, IRandomizer randomizer = null)
        {
            _squareFactory = squareFactory;
            _randomizer = randomizer ?? new DefaultRandomizer();

            _boardSize = 4 * 4;
            _verticalSlideOffset = 4;
            _horizontalSlideOffset = 1;
        }

        public IEnumerable<Square> Board => _board?.ToArray() ?? Enumerable.Empty<Square>();

        /// <summary>
        /// Starts the game by generating the squares in random places leaving one empty square.
        /// </summary>
        public void Start()
        {
            // Init random positions sequence.
            var randomPositions = _randomizer.GenerateRandomSequence(_boardSize);

            // Init empty squares board.
            _board = new Square[_boardSize];

            // Generate squares according to their position and put on board.
            for (var i = 0; i < _boardSize - 1; i++)
            {
                var randomPosition = randomPositions[i];
                _board[randomPosition] = _squareFactory.CreateByPosition(i);
            }

            // The last square is empty, save it's index to optimize calculation.
            _emptySquarePosition = randomPositions.Last();
        }

        /// <summary>
        /// Slides up the square that is under the empty place to that empty place.
        /// </summary>
        public void SlideUp()
        {
            if (_emptySquarePosition + _verticalSlideOffset >= _boardSize)
                return; // Or throw an exception...

            Slide(_emptySquarePosition + _verticalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides down the square that is above the empty place to that empty place.
        /// </summary>
        public void SlideDown()
        {
            if (_emptySquarePosition - _verticalSlideOffset < 0)
                return; // Or throw an exception...

            Slide(_emptySquarePosition - _verticalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides right the square that is on the left side of the empty place. 
        /// </summary>
        public void SlideRight()
        {
            if (_emptySquarePosition % 4 - _horizontalSlideOffset < 0)
                return; // Or throw an exception...
            
            Slide(_emptySquarePosition - _horizontalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides left the square that is on the right side (of heaven) of the empty place.
        /// </summary>
        public void SlideLeft()
        {
            if (_emptySquarePosition % 4 + _horizontalSlideOffset >= 4)
                return; // Or throw an exception...

            Slide(_emptySquarePosition + _horizontalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides square on the given position to the empty place.
        /// </summary>
        private void Slide(int squareToSlidePosition)
        {
            var squareToSlide = _board[squareToSlidePosition];

            _board[squareToSlidePosition] = null;
            _board[_emptySquarePosition] = squareToSlide;
            _emptySquarePosition = squareToSlidePosition;
        }

        private void Verify()
        {
            // TODO Very strange method that is about to be rewrited...
            
            for (int i = 0; i < _boardSize; i++)
            {
                if (_board[i] == null) return;
                if (_board[i].CorrectPosition != i) return;
            }

            throw new Exception("You won!");
        }
        
        private enum GameState
        {
            Waiting,
            Started,
            Finished
        }
    }
}