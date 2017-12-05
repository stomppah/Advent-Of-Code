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
            char newLine = Convert.ToChar(13);
            char tab = Convert.ToChar(9);

            string[] rowdata = spreadsheet.Split(newLine);

            List<long[]> table = new List<long[]>();
            long[] rowLongData;
            for (int i = 0; i <= rowdata.Length-1; i++)
            {
                rowdata[i] = rowdata[i].TrimStart('\n');
                var rowStringData = rowdata[i].Contains('\t') ? rowdata[i].Split('\t') : rowdata[i].Split(' ');
                rowLongData = new long[rowStringData.Length];
                for (int j = 0; j <= rowStringData.Length-1; j++)
                {
                    Int64.TryParse(rowStringData[j], out rowLongData[j]);
                }
                table.Add(rowLongData);
            }

            double runningTotal = 0;
            foreach (var row in table)
            {
                runningTotal += row.Max() - row.Min();
            }

            return runningTotal;
        }

        public double CalculateChecksumExtended(string spreadsheet)
        {
            char newLine = Convert.ToChar(13);
            char tab = Convert.ToChar(9);

            string[] rowdata = spreadsheet.Split(newLine);

            List<long[]> table = new List<long[]>();
            long[] rowLongData;
            for (int i = 0; i <= rowdata.Length - 1; i++)
            {
                rowdata[i] = rowdata[i].TrimStart('\n');
                var rowStringData = rowdata[i].Contains('\t') ? rowdata[i].Split('\t') : rowdata[i].Split(' ');
                rowLongData = new long[rowStringData.Length];
                for (int j = 0; j <= rowStringData.Length - 1; j++)
                {
                    Int64.TryParse(rowStringData[j], out rowLongData[j]);
                }
                table.Add(rowLongData);
            }

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
