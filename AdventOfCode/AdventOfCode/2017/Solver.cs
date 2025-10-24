using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public class Solver
    {
        /**
           Converts the input string into digits, traverses the circular list by comparing each digit to its immediate 
           successor (wrapping the last digit back to the first), collects the matches, and returns their sum.
         */
        public double SumOfRepeatedNumbersNextDigit(string sequence)
        {
            var digits = sequence.ConvertToLongArray();

            var matches = new List<long>();
            for (var digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                var nextDigitInSequence = digitIndex < digits.Length - 1 ? digits[digitIndex + 1] : digits[0];
                if (digits[digitIndex] == nextDigitInSequence)
                {
                    matches.Add(digits[digitIndex]);
                }
            }

            return matches.Sum();
        }

        /**
           Performs the same conversion while looking half the list length ahead, with modular wraparound. 
           It sums the values of digits that match their midpoint partner to implement Day 1 part 2. 
         */
        public double SumOfRepeatedNumbersExtended(string sequence)
        {
            var digits = sequence.ConvertToLongArray();
            var deltaIndex = digits.Length / 2;

            var matches = new List<long>();
            for (var digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                long nextDigitInSequence;
                if ((digitIndex + deltaIndex) <= digits.Length - 1)
                {
                    nextDigitInSequence = digits[digitIndex + deltaIndex];
                }
                else
                {
                    nextDigitInSequence = digits[(digitIndex + deltaIndex) - (digits.Length)];
                }
                if (digits[digitIndex] == nextDigitInSequence)
                {
                    matches.Add(digits[digitIndex]);
                }
            }

            return matches.Sum();
        }

        /**
           Examines each ordered pair in every parsed row to find evenly divisible numbers (excluding self-pairs), 
           accumulates each division result per row, and sums those quotients for the final checksum, 
           delivering Day 2 part 2.
         */
        public double CalculateChecksum(string spreadsheet)
        {
            var table = spreadsheet.ConvertToList();

            double runningTotal = 0;
            foreach (var row in table)
            {
                runningTotal += row.Max() - row.Min();
            }

            return runningTotal;
        }

        public double CalculateChecksumExtended(string spreadsheet)
        {
            var table = spreadsheet.ConvertToList();

            double runningTotal = 0;
            foreach (var row in table)
            {
                double divisionSum = 0;
                for (var rowIndex = 0; rowIndex < row.Length; rowIndex++)
                {
                    for (var nestedIndex = 0; nestedIndex < row.Length; nestedIndex++)
                    {
                        if (row[rowIndex] % row[nestedIndex] == 0 && rowIndex != nestedIndex)
                        {
                            // ReSharper disable once PossibleLossOfFraction
                            divisionSum += row[rowIndex] / row[nestedIndex];
                        }
                    }
                }
                runningTotal += divisionSum;
            }

            return runningTotal;
        }
    }
}
