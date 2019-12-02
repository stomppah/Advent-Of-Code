using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
    public static class StringExtensions
    {

        public static long[] ConvertToLongArray(this string sequence)
        {
            long[] digits = new long[sequence.Length];
            for (int sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
            {
                long digit;
                Int64.TryParse(sequence.Substring(sequenceIndex, 1), out digits[sequenceIndex]);
            }
            return digits;
        }

        public static List<long[]> ConvertToList(this string spreadsheet)
        {
            List<long[]> table = new List<long[]>();
            char newLine = Convert.ToChar(13);
            string[] rowdata = spreadsheet.Split(newLine);
            for (int i = 0; i <= rowdata.Length - 1; i++)
            {
                rowdata[i] = rowdata[i].TrimStart('\n');
                var rowStringData = rowdata[i].Contains('\t') ? rowdata[i].Split('\t') : rowdata[i].Split(' ');
                var rowLongData = new long[rowStringData.Length];
                for (int j = 0; j <= rowStringData.Length - 1; j++)
                {
                    Int64.TryParse(rowStringData[j], out rowLongData[j]);
                }
                table.Add(rowLongData);
            }
            return table;
        }
    }
}
