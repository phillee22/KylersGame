using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Manager
    {
        Board _b;

        public Manager(Board B)
        {
            this._b = B;
        }


        private bool NoCollisions(Coordinate BoardLocation, BoardPiece Piece)
        {
            Coordinate translated;

            foreach (Coordinate c in Piece.Coordinates)
            {
                // translate the piece's coordiate into a board coordinate.
                translated = new Coordinate((BoardLocation.X + c.X), (BoardLocation.Y + c.Y));

                // check the state of that coordinate.
                if (_b._squares[translated.X, translated.Y].State == SquareState.Occupied)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PieceFits(BoardPiece Piece, out Coordinate Location)
        {
            Coordinate tryhere;

            for (int x = 0; x < _b.XWidth; x++)
            {
                for (int y = 0; y < _b.YHeight; y++)
                {
                    // If there are no collisions for this piece at the board's
                    // "try here" coord, then return true - the piece fits...
                    tryhere = new Coordinate(x, y);
                    if (NoCollisions(tryhere, Piece))
                    {
                        Location = tryhere;
                        return true;
                    }
                }
            }

            // tried all the board's locations and nothing fits...
            Location = null;
            return false;
        }

        public void PlacePiece(BoardPiece Piece, Coordinate BoardLocation)
        {
            // translate the piece's coordiate into a board coordinate.
            Coordinate translated;

            foreach (Coordinate c in Piece.Coordinates)
            {
                translated = new Coordinate((BoardLocation.X + c.X), (BoardLocation.Y + c.Y));
                // check the state of that coordinate.
                _b._squares[translated.X, translated.Y].State = SquareState.Occupied;
            }
        }
    }
}
