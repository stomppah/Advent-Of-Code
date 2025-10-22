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

		public static int[,] ConvertToGrid(this string data)
        {
            string[] lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			int rows = lines.Length;
			int cols = lines[0].Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;

			int[,] grid = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				string[] parts = lines[r].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
				for (int c = 0; c < cols; c++)
				{
					grid[r, c] = int.Parse(parts[c]);
				}
			}

			return grid;
        }

		public static double[] FindInputIndex(this double[,] grid, int input)
		{

			int x = 0;
			int y = 0;
			
			var rowLength = grid.GetLength(0);
			var colLength = grid.GetLength(1);

			if (input == 1)
            {
                return new double[] { rowLength / 2, colLength / 2 };
            }

            for (int row= 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    if(grid[row, col] == input)
                    {
                        x=row;
                        y=col;
                        break;
                    }
                }
            }

			double[] coords = new double[2];
			coords[0] = x;
			coords[1] = y;

			return coords;
		}

		public static double FindShortestPath(this double[,] grid, int input)
		{
			double[] exitIndex = grid.FindInputIndex(1);
			double[] startIndex = grid.FindInputIndex(input);

			double result = 0;

			if (exitIndex[0] == startIndex[0] && exitIndex[1] == startIndex[1])
			{
				return result;
			}
			// Input: 11
			// exitIndex = 866, 866
			// startIndex = 866, 868
			// if (866 < 866)
			if (exitIndex[0] < startIndex[0])
			{
				// Not taken
				result += startIndex[0] - exitIndex[0]; 
			}
			// elseif (866 > 866)
			else if (exitIndex[0] > startIndex[0])
			{
				// Not taken
				result += startIndex[0] + exitIndex[0];		
			}

			// if (866 < 868)
			if (exitIndex[1] < startIndex[1])
			{
				// result = 868 - 866 = 2
				result += startIndex[1] - exitIndex[1];
			}
			// elseif (866 > 868)
			else if (exitIndex[1] > startIndex[1])
			{
				result += startIndex[1] + exitIndex[1];
			}

			// result
			return result;
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
