using System;
using System.Collections;
using GameEngine;

namespace KylersGame
{
    class Program
    {
        static Board _b = null;
        static ArrayList _pieces = new ArrayList();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CreateBoard();

            CreatePieces();

            PlacePieces();

        }

        static void CreateBoard()
        {
            _b = new Board(8, 8);
        }

        static void CreatePieces()
        {
            Coordinate[] coords = new Coordinate[] { new Coordinate(0,0),
                                                     new Coordinate(1,0),
                                                     new Coordinate(0,1),
                                                     new Coordinate(1,1) };
            
            BoardPiece bp = new BoardPiece(coords);
            _pieces.Add(bp);

            coords = new Coordinate[] { new Coordinate(0,0),
                                        new Coordinate(0,1) };

            bp = new BoardPiece(coords);
            _pieces.Add(bp);
        }

        static void PlacePieces()
        {
            Manager m = new Manager(_b);
            Coordinate loc;

            foreach (BoardPiece bp in _pieces)
            {
                if (m.PieceFits(bp, out loc))
                {
                    Console.WriteLine(" !! Piece fits at " + loc.ToString());
                    m.PlacePiece(bp, loc);
                }
            }
        }
    }
}
