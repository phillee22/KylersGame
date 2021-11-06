using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class RandomManager : PieceManager
    {

        int _limit;

        public RandomManager(Board B, int JumpLimit) : base(B)
        {
            this._limit = JumpLimit;
        }


        public override bool PieceFits(BoardPiece Piece, out Coordinate Location)
        {
            Coordinate tryhere;
            int x = 0;
            int y = 0;
            var rand = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < _limit; i++)
            {
                x = rand.Next(_b.XWidth);
                y = rand.Next(_b.YHeight);

                // If there are no collisions for this piece at the board's
                // "try here" coord, then return true - the piece fits...
                tryhere = new Coordinate(x, y);
                if (NoCollisions(tryhere, Piece))
                {
                    Location = tryhere;
                    return true;
                }
            }

            // tried all the board's locations and nothing fits...
            Location = null;
            return false;
        }
    }
}
