using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Problems.ProblemFive
{
    public class ProblemFive : Problem
    {
        public override string Solve()
        {
            var debug = false;
            var inputFile = debug ? "test_input" : "input";

            var seatStrings = this.ReadInput(inputFile).Split("\n").Select(x => x.Replace("\r", string.Empty)).ToList();
            int maxSeatId = 0;

            var seatIdsBooked = new HashSet<int>();

            foreach(var seatString in seatStrings)
            {
                this.ParseSeat(seatString, out var seatRow, out var seatColumn, out var seatId);

                if (debug)
                {
                    Console.WriteLine($"{seatString}: Row {seatRow}, Column {seatColumn}, Id {seatId}");
                }

                seatIdsBooked.Add(seatId);
                maxSeatId = Math.Max(seatId, maxSeatId);
            }

            var mySeatId = -1;
            for (int row = 0; row <= 127; row++)
            {
                for (int column = 0; column <= 7; column++)
                {
                    var seatId = this.GetSeatId(row, column);

                    if (!seatIdsBooked.Contains(seatId) && seatIdsBooked.Contains(seatId - 1) && seatIdsBooked.Contains(seatId + 1))
                    {
                        mySeatId = seatId;
                        break;
                    }
                }

                if (mySeatId != -1)
                {
                    break;
                }
            }

            return $"The max seat id is {maxSeatId}! My seat id is {mySeatId}";
        }

        private int GetSeatId(int row, int column) => row * 8 + column;

        private void ParseSeat(string seatString, out int row, out int column, out int seatId)
        {
            var rowString = seatString.Substring(0, 7);
            var columnString = seatString.Substring(7, 3);

            row = this.GetSeatRowOrColumn(rowString, 0, 127);
            column= this.GetSeatRowOrColumn(columnString, 0, 7);

            seatId = this.GetSeatId(row, column);
        }

        /// <summary>
        /// Gets the seat row or column.
        /// </summary>
        /// <param name="seatString">The seat string.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <returns></returns>
        private int GetSeatRowOrColumn(string seatString, int lowerBound, int upperBound)
        {
            // Look at the first letter of the row string
            var seatLetter = seatString.Substring(0, 1);

            if (string.Equals(seatLetter, "F") || string.Equals(seatLetter, "L"))
            {
                if (seatString.Length == 1)
                {
                    return lowerBound;
                }

                var midPoint = (int)Math.Floor((decimal)(lowerBound + upperBound) / 2);
                return this.GetSeatRowOrColumn(seatString.Substring(1, seatString.Length - 1), lowerBound, midPoint);
            }

            if (string.Equals(seatLetter, "B") || string.Equals(seatLetter, "R"))
            {
                if (seatString.Length == 1)
                {
                    return upperBound;
                }

                var midPoint = (int)Math.Ceiling((decimal)(lowerBound + upperBound) / 2);
                return this.GetSeatRowOrColumn(seatString.Substring(1, seatString.Length - 1), midPoint, upperBound);
            }

            // Shouldn't get here with valid input
            return -1;
        }
    }
}
