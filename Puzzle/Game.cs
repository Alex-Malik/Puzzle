using System.Collections.Generic;
using System.Linq;
using Puzzle.Exceptions;

namespace Puzzle
{
    /// <summary>
    /// Represent the game logic with all game mechanics. This class is the entry
    /// point to the business logic of the app.
    /// </summary>
    public class Game
    {
        // Dependencies.
        private readonly ISquareFactory _squareFactory;
        private readonly IRandomizer _randomizer;

        // Game settings.
        private readonly int _boardWidth;
        private readonly int _boardHeight;
        private readonly int _boardSize;
        private readonly int _verticalSlideOffset;
        private readonly int _horizontalSlideOffset;

        // Game constants & variables.
        private const int DefaultBoardWidth = 4;
        private const int DefaultBoardHeight = 4;
        private Square[] _board;
        private int _emptySquarePosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class. If no arguments provided the default values will be used.
        /// </summary>
        public Game(ISquareFactory squareFactory, IRandomizer randomizer = null)
        {
            _squareFactory = squareFactory;
            _randomizer = randomizer ?? new DefaultRandomizer();

            // In case if some time the size of the board will be bigger then 
            // the main logic will not change, and only constructor should be
            // extended to support custom width and height.
            _boardWidth = DefaultBoardWidth;
            _boardHeight = DefaultBoardHeight;
            
            _boardSize = _boardWidth * _boardHeight;
            _verticalSlideOffset = _boardWidth;
            _horizontalSlideOffset = 1;
        }

        /// <summary>
        /// Gets a collection of the squares that represents the game board.
        /// </summary>
        public IEnumerable<Square> Board => _board?.ToArray() ?? Enumerable.Empty<Square>();
        
        /// <summary>
        /// Gets a value indicating whether or not the game is finished.
        /// </summary>
        public bool IsFinished { get; private set; } = false;

        /// <summary>
        /// Starts the game by generating the squares in random places leaving one empty square.
        /// </summary>
        public void Start()
        {
            if (_board != null && _board.Any())
                throw new GameAlreadyStartedException();
            
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
        /// Restarts the current game. This action will erase all progress.
        /// </summary>
        public void Restart()
        {
            _board = null;
            IsFinished = false;
            Start();
        }

        /// <summary>
        /// Slides up the square that is under the empty place to that empty place.
        /// </summary>
        public void SlideUp()
        {
            if (_board == null || !_board.Any())
                throw new GameNotStartedException();
            if (IsFinished)
                throw new GameFinishedException();
            if (_emptySquarePosition + _verticalSlideOffset >= _boardSize)
                return;

            Slide(_emptySquarePosition + _verticalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides down the square that is above the empty place to that empty place.
        /// </summary>
        public void SlideDown()
        {
            if (_board == null || !_board.Any())
                throw new GameNotStartedException();
            if (IsFinished)
                throw new GameFinishedException();
            if (_emptySquarePosition - _verticalSlideOffset < 0)
                return;

            Slide(_emptySquarePosition - _verticalSlideOffset);
            Verify();
        }

        /// <summary>
        /// Slides right the square that is on the left side of the empty place. 
        /// </summary>
        public void SlideRight()
        {
            if (_board == null || !_board.Any())
                throw new GameNotStartedException();
            if (IsFinished)
                throw new GameFinishedException();
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
            if (_board == null || !_board.Any())
                throw new GameNotStartedException();
            if (IsFinished)
                throw new GameFinishedException();
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

        /// <summary>
        /// Verifies if the game is finished.
        /// </summary>
        private void Verify()
        {
            for (int i = 0; i < _boardSize - 1; i++)
            {
                if (_board[i] == null) return;
                if (_board[i].CorrectPosition != i) return;
            }
            if (_board.Last() == null) IsFinished = true;
        }
    }
}