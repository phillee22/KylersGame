using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    //
    //  This PieceManager uses a brute force algorythm to locate places on the
    //  board to see if the given piece will fit.
    //
    public class BruteForceManager : PieceManager
    {

        public BruteForceManager(Board B) : base(B)
        {

        }

        public override bool PieceFits(BoardPiece Piece, out Coordinate Location)
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
    }
}
