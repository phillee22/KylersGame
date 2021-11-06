using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    //
    //  This is the abstract base class for the objects that attempt to place pieces
    //  on the game board.  It provides the simple/obvious functions like checking
    //  for collisions.
    //
    public abstract class PieceManager
    {
        internal Board _b;

        public PieceManager(Board B)
        {
            this._b = B;
        }


        public bool NoCollisions(Coordinate BoardLocation, BoardPiece Piece)
        {
            Coordinate translated;

            foreach (Coordinate c in Piece.Coordinates)
            {
                // translate the piece's coordiate into a board coordinate.
                translated = new Coordinate((BoardLocation.X + c.X), (BoardLocation.Y + c.Y));

                // Check the state of that translated coordinate.
                // Given the starting location, a piece's translated coords could be off the board.
                // Catch that exception and return false...
                try
                {
                    if (_b._squares[translated.X, translated.Y].State == SquareState.Occupied)
                    {
                        return false;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
#if DEBUG
                    Console.WriteLine(" DEBUG:  out of bounds - ({0},{1}). trans - ({2},{3})", BoardLocation.X, BoardLocation.Y, translated.X, translated.Y);
#endif
                    return false;
                }
            }

            return true;
        }

        public abstract bool PieceFits(BoardPiece Piece, out Coordinate Location);

        public void PlacePiece(BoardPiece Piece, Coordinate BoardLocation)
        {
            // translate the piece's coordiate into a board coordinate.
            Coordinate translated;

            foreach (Coordinate c in Piece.Coordinates)
            {
                translated = new Coordinate((BoardLocation.X + c.X), (BoardLocation.Y + c.Y));
                // check the state of that coordinate.
                _b._squares[translated.X, translated.Y].State = SquareState.Occupied;
                _b._squares[translated.X, translated.Y].OuputColor = Piece.OutputColor;
            }
        }
    }
}
