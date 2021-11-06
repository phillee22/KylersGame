using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class BoardPiece : Shape
    {
        public string Name;
        public ConsoleColor OutputColor;

        public BoardPiece(string Name, Coordinate[] Coordinates, ConsoleColor OutputColor)
        {
            this.Name = Name;
            this.Coordinates = new System.Collections.ArrayList(Coordinates);
            this.OutputColor = OutputColor;
        }
    }
}
