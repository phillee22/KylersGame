using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    //
    //  the board's origin is bottom-left so all the board squares re in the "first quadrant."
    //  therefore, coordinates are read right and up - 
    //

    public class Board
    {
        int _yh;
        int _xw;
        public BoardSquare[,] _squares;

        public Board()
        {
            _yh = _xw = 5;
            _squares = new BoardSquare[_yh,_xw];
        }

        public Board(int YHeight, int XWidth)
        {
            _yh = YHeight;
            _xw = XWidth;
            _squares = new BoardSquare[_yh, _xw];
            for (int x = 0; x < _xw; x++)
            {
                for (int y = 0; y < _yh; y++)
                {
                    _squares[x, y] = new BoardSquare();
                    _squares[x, y].State = SquareState.Empty;
                }
            }
        }

        public int YHeight
        {
            get { return _yh; }
        }
        public int XWidth
        {
            get { return _xw; }
        }
    }
}
