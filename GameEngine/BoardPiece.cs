using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class BoardPiece : Shape
    {
        public BoardPiece(Coordinate[] Coordinates)
        {
            this.Coordinates = new System.Collections.ArrayList(Coordinates);
        }
    }
}
