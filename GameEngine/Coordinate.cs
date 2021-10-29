using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Coordinate
    {
        public int X = 0;   // measures to the right -> an X coord
        public int Y = 0;   // measures up -> a Y coord

        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return (" X = " + X + ", Y = " + Y);
        }
    }
}
