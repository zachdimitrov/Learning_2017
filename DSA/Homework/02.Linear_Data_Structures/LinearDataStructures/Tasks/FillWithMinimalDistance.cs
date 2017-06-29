using LinearDataStructures.Utilities;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace LinearDataStructures.Tasks
{
    internal class FillWithMinimalDistance
    {
        private const string ErrorMessage = "Initial matrix is in the code!";
        private const string Title = "  14. FILL MATRIX WITH MINIMAL DISTANCES";
        private const string Header = @"  You can change the initial matrix from the source.
  Press enter to finish.";

        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Header);

            Tuple<int, int> startPoint = FindStart();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Initial matrix");
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrintLabyrinth();
            FillLabyrinth(startPoint);
            FillUnreachable();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Result matrix");
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrintLabyrinth();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  Next?  ");
            Console.ReadKey(true);
        }

        static string[,] labyrinth = new string[,]
        {
            { "0", "0", "0", "x", "0", "x"},
            { "0", "x", "0", "x", "0", "x"},
            { "0", "*", "x", "0", "x", "0"},
            { "0", "x", "0", "0", "0", "0"},
            { "0", "0", "0", "x", "x", "0"},
            { "0", "0", "0", "x", "0", "x"},
        };

        static void FillLabyrinth(Tuple<int, int> startPoint)
        {
            // create list of possible points for each direction
            List<Tuple<int, int>> currentListOfPoints = new List<Tuple<int, int>>(4);

            // add start point
            currentListOfPoints.Add(startPoint);

            // increment iterations
            int waveCount = 1;

            while (currentListOfPoints.Count > 0)
            {
                // next list of possible points for each direction
                List<Tuple<int, int>> nextListOfPoints = new List<Tuple<int, int>>(4);

                // check if step for each direction is possible and add it to list
                foreach (Tuple<int, int> point in currentListOfPoints)
                {
                    if (CheckPoint(point.Item1 - 1, point.Item2)) //UP
                    {
                        nextListOfPoints.Add(new Tuple<int, int>(point.Item1 - 1, point.Item2));
                        labyrinth[point.Item1 - 1, point.Item2] = waveCount.ToString();
                    }
                    if (CheckPoint(point.Item1, point.Item2 + 1)) //RIGHT
                    {
                        nextListOfPoints.Add(new Tuple<int, int>(point.Item1, point.Item2 + 1));
                        labyrinth[point.Item1, point.Item2 + 1] = waveCount.ToString();
                    }
                    if (CheckPoint(point.Item1 + 1, point.Item2)) //DOWN
                    {
                        nextListOfPoints.Add(new Tuple<int, int>(point.Item1 + 1, point.Item2));
                        labyrinth[point.Item1 + 1, point.Item2] = waveCount.ToString();
                    }
                    if (CheckPoint(point.Item1, point.Item2 - 1)) //LEFT
                    {
                        nextListOfPoints.Add(new Tuple<int, int>(point.Item1, point.Item2 - 1));
                        labyrinth[point.Item1, point.Item2 - 1] = waveCount.ToString();
                    }
                }

                if (nextListOfPoints.Count > 0)
                {
                    currentListOfPoints = nextListOfPoints;
                }
                else
                {
                    currentListOfPoints.Clear();
                }

                waveCount++;
            }
        }

        static bool CheckPoint(int row, int col)
        {
            if ((row < 0 || row >= labyrinth.GetLength(0)) || (col < 0 || col >= labyrinth.GetLength(1)))
            {
                return false;
            }
            else if (labyrinth[row, col] == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void FillUnreachable()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        static Tuple<int, int> FindStart()
        {
            Tuple<int, int> startPoint = new Tuple<int, int>(-10, -10);
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startPoint = new Tuple<int, int>(row, col);
                        return startPoint;
                    }
                }
            }
            return startPoint;
        }

        static void PrintLabyrinth()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0,3}", labyrinth[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}