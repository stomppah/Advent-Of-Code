using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class MyExtensions
    {

        public static long[] ConvertToLongArray(this string sequence)
        {
            long[] digits = new long[sequence.Length];
            for (int sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
            {
                Int64.TryParse(sequence.Substring(sequenceIndex, 1), out digits[sequenceIndex]);
            }
            return digits;
        }

        public static List<long[]> ConvertToList(this string spreadsheet)
        {
            List<long[]> table = new List<long[]>();
            string[] rowdata = spreadsheet.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <= rowdata.Length - 1; i++)
            {
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

		// https://rosettacode.org/wiki/Tokenize_a_string_with_escaping#C.23
		public static IEnumerable<string> Tokenize(this string input, char separator = '\n', char escape = '^')
		{
			if (input == null) yield break;
			var buffer = new StringBuilder();
			bool escaping = false;
			foreach (char c in input)
			{
				if (escaping)
				{
					buffer.Append(c);
					escaping = false;
				}
				else if (c == escape)
				{
					escaping = true;
				}
				else if (c == separator)
				{
					yield return buffer.Flush();
				}
				else
				{
					buffer.Append(c);
				}
			}
			if (buffer.Length > 0 || input[input.Length - 1] == separator) yield return buffer.Flush();
		}

		public static string Flush(this StringBuilder stringBuilder)
		{
			string result = stringBuilder.ToString();
			stringBuilder.Clear();
			return result;
		}
	}
}
