using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Core
{
    public class Solver
    {
        public double SumOfRepeatedNumbersNextDigit(string sequence)
        {
            long[] digits = sequence.ConvertToLongArray();

            List<long> matches = new List<long>();
            for (int digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                var nextDigitInSequence = digitIndex < digits.Length - 1 ? digits[digitIndex + 1] : digits[0];
                if (digits[digitIndex] == nextDigitInSequence)
                {
                    matches.Add(digits[digitIndex]);
                }
            }

            return matches.Sum();
        }

        public double SumOfRepeatedNumbersExtended(string sequence)
        {
            long[] digits = sequence.ConvertToLongArray();
            var deltaIndex = digits.Length / 2;

            List<long> matches = new List<long>();
            for (int digitIndex = 0; digitIndex < digits.Length; digitIndex++)
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
                for (int rowIndex = 0; rowIndex < row.Length; rowIndex++)
                {
                    for (int nestedIndex = 0; nestedIndex < row.Length; nestedIndex++)
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
