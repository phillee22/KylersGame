using System;
using System.Collections;
using GameEngine;

namespace KylersGame
{
    class Program
    {
        static Board _b = null;
        static ArrayList _pieces = new ArrayList();
        static int _h, _w;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!  {0}", 1);

            if (args.Length > 0)
            {
                ParseCmdLine(args);
            }

            CreateBoard();
            _b.Print();

            CreatePieces();

            PlacePieces();

        }

        static void CreateBoard()
        {
            _b = new Board(_h, _w);
        }

        static void CreatePieces()
        {
            // 2x2
            Coordinate[] coords = new Coordinate[] { new Coordinate(0,0),
                                                     new Coordinate(1,0),
                                                     new Coordinate(0,1),
                                                     new Coordinate(1,1) };
            
            BoardPiece bp = new BoardPiece("2x2", coords, ConsoleColor.Red);
            _pieces.Add(bp);
            _pieces.Add(bp);

            // 1x2
            coords = new Coordinate[] { new Coordinate(0,0),
                                        new Coordinate(0,1) };

            bp = new BoardPiece("1x2", coords, ConsoleColor.Yellow);
            _pieces.Add(bp);
            _pieces.Add(bp);

            // left 3-stair:
            //   x
            //   x x
            //   x x x
            coords = new Coordinate[] { new Coordinate(0,0),
                                        new Coordinate(1,0),
                                        new Coordinate(2,0),
                                        new Coordinate(0,1),
                                        new Coordinate(0,2),
                                        new Coordinate(1,1) };

            bp = new BoardPiece("left 3-stair", coords, ConsoleColor.Cyan);
            _pieces.Add(bp);

            // right L:
            //     x
            //     x
            //   x x
            coords = new Coordinate[] { new Coordinate(0,0),
                                        new Coordinate(1,0),
                                        new Coordinate(1,1),
                                        new Coordinate(2,1) };

            bp = new BoardPiece("right L", coords, ConsoleColor.White);
            _pieces.Add(bp);
        }

        static void ParseCmdLine(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("/h"))
                {
                    i++;
                    _h = int.Parse(args[i]);
                }
                else if (args[i].Contains("/w"))
                {
                    i++;
                    _w = int.Parse(args[i]);
                }
            }
        }


        static void PlacePieces()
        {
            Console.WriteLine(" Getting a brute force placement manager.");

            PieceManager m = new BruteForceManager(_b);
            Coordinate loc;

            foreach (BoardPiece bp in _pieces)
            {
                if (m.PieceFits(bp, out loc))
                {
                    Console.WriteLine(" !! Piece {0} fits at {1}", bp.Name, loc.ToString());
                    m.PlacePiece(bp, loc);
                }
            }

            Console.WriteLine();
            Console.WriteLine("  Here's board:");
            Console.WriteLine();
            _b.Print();

            Console.WriteLine();
            Console.WriteLine("  !! clearing the board...");
            Console.WriteLine();
            _b.Clear();

            Console.WriteLine(" Getting a random placement manager.");
            m = new RandomManager(_b, 10);

            foreach (BoardPiece bp in _pieces)
            {
                if (m.PieceFits(bp, out loc))
                {
                    Console.WriteLine(" !! Piece {0} fits at {1}", bp.Name, loc.ToString());
                    m.PlacePiece(bp, loc);
                }
            }
        }
    }
}
