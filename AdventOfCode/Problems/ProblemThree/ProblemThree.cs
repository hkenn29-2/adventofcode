using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Problems.ProblemThree
{
    public class ProblemThree : IProblem
    {
        public string Solve()
        {
            // Load the map into a mxn matrix
            var map = this.LoadMap();

            var slopes = new List<(int RowMovement, int ColumnMovement)>()
            {
                (1, 1),
                (1, 3),
                (1, 5),
                (1, 7),
                (2, 1)
            };

            // Important we multiply with double, using int results in overflows
            double treeMultiplied = 1;

            var solutionString = new StringBuilder();
            foreach (var slope in slopes)
            {
                int rowPosition = 0;
                int columnPosition = 0;
                int treeCount = 0;

                string[,] debugMap = null;
                if (Program.GlobalSettings.Debug)
                {
                    debugMap = this.LoadDebugMap(map);
                }

                while (rowPosition < map.GetLength(0) - 1)
                {
                    // Move column position + 3, row Position + 1. At the same time, we mod the column to wrap
                    rowPosition += slope.RowMovement;
                    columnPosition = (columnPosition + slope.ColumnMovement) % map.GetLength(1);

                    // Check if we have hit a tree
                    if (map[rowPosition, columnPosition])
                    {
                        treeCount++;
                    }
                    
                    if (Program.GlobalSettings.Debug)
                    {
                        debugMap[rowPosition, columnPosition] = map[rowPosition, columnPosition] ? "X" : "O";
                    }
                }

                if (Program.GlobalSettings.Debug)
                {
                    this.PrintMap(debugMap);
                }

                solutionString.Append($"We have hit {treeCount} trees when moving {slope.ColumnMovement} right and {slope.RowMovement} down! Map size was {map.GetLength(0)}x{map.GetLength(1)}");
                solutionString.Append(Environment.NewLine);

                treeMultiplied *= treeCount;
            }

            solutionString.Append($"When all tree counts are multiplied together we get {treeMultiplied}");
            return solutionString.ToString();
        }

        private void PrintMap(object[,] map)
        {
            Console.WriteLine(string.Empty);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine(string.Empty);
            }
        }

        private string[,] LoadDebugMap(bool[,] map)
        {
            var matrix = new string[map.GetLength(0), map.GetLength(1)];

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    matrix[i, j] = map[i, j] ? "#" : ".";
                }
            }

            return matrix;
        }

        private bool[,] LoadMap()
        {
            var inputLines = File.ReadAllText("Problems\\ProblemThree\\input").Replace("\r", string.Empty).Split("\n");

            // Figure out how many rows and columns there are
            var rows = inputLines.Length;
            var columns = inputLines[0].Length;

            // Create the matrix
            var matrix = new bool[rows, columns];

            for (int i = 0; i < inputLines.Length; i++)
            {
                for (int j = 0; j < inputLines[i].Length; j++)
                {
                    matrix[i, j] = inputLines[i][j] != '.'; 
                }
            }

            return matrix;
        }
    }
}
