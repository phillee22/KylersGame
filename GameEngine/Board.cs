using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    //
    //  At its core, this board is a 2D array of BoardSquares.
    //
    //  The board's origin is bottom-left so all the board squares are in the "first quadrant."
    //  Therefore, coordinates are read right and up - the bottom left corner of square is the 
    //  coordinate's "location."
    //
    //  Also, this is really a "console" board since it relies on the Console object to 
    //  print the output of the board...
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

        public void Clear()
        {
            for (int x = 0; x < _xw; x++)
            {
                for (int y = 0; y < _yh; y++)
                {
                    _squares[x, y].State = SquareState.Empty;
                }
            }
        }

        public void Print()
        {
            ConsoleColor currentFG = Console.ForegroundColor;

            // Print the top row's top edge.
            Console.WriteLine("    _______________________________________");

            // Print all the values of each row's squares - starting with the index of row.
            for (int y = (_yh-1); y >= 0; y--)
            {
                Console.Write( " {0} ", y);
                for (int x = 0; x < _xw; x++)
                {
                    Console.Write("|");
                    Console.Write("_");
                    if (_squares[x, y].State == SquareState.Empty)
                    {
                        Console.Write("___");
                    }
                    else
                    {
                        Console.Write("_");
                        Console.ForegroundColor = _squares[x, y].OuputColor;
                        Console.Write("X");
                        Console.ForegroundColor = currentFG;
                        Console.Write("_");
                    }
                }
                Console.WriteLine("|");
            }

            // Print the indices of the columns.
            Console.Write("    ");  // add a little left margin...
            for (int x = 0; x < XWidth; x++)
            {
                Console.Write("  {0}  ", x);
            }
            Console.WriteLine();
        }
    }
}
