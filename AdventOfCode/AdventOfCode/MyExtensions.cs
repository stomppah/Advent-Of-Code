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
            var digits = new long[sequence.Length];
            for (var sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
            {
                Int64.TryParse(sequence.Substring(sequenceIndex, 1), out digits[sequenceIndex]);
            }
            return digits;
        }
        private static readonly char[] Separator = ['\r', '\n'];

        public static List<long[]> ConvertToList(this string spreadsheet)
        {
            var table = new List<long[]>();
            var rowdata = spreadsheet.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i <= rowdata.Length - 1; i++)
            {
                var rowStringData = rowdata[i].Contains('\t') ? rowdata[i].Split('\t') : rowdata[i].Split(' ');
                var rowLongData = new long[rowStringData.Length];
                for (var j = 0; j <= rowStringData.Length - 1; j++)
                {
                    Int64.TryParse(rowStringData[j], out rowLongData[j]);
                }
                table.Add(rowLongData);
            }
            return table;
        }
        
        public static List<string[]> ConvertToPassphraseList(this string input)
        {
	        var rowData = input.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

	        return rowData.Select(row => row.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

        public static int CountValidPassphrases(this List<string[]> input)
        {
	        var validCount = 0;
	        foreach (var passphrase in input)
	        {
		        var uniqueWords = new HashSet<string>(passphrase);
		        var normalisedUniqueWords = uniqueWords.Select(row =>
		        {
			        return string.Concat(row.OrderBy(c => c));
		        }).ToHashSet();
		        if (normalisedUniqueWords.Count == passphrase.Length)
		        {
			        validCount++;
		        }
	        }

	        return validCount;
        }

		public static int[,] ConvertToGrid(this string data)
		{
			if (data == "")
			{
				throw new ArgumentException("Input data cannot be empty.");
			}
			if (data == null)
			{
				throw new ArgumentNullException($"Input data cannot be null.");
			}
			
            var lines = data.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
			var rows = lines.Length;
			var cols = lines[0].Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;

			var grid = new int[rows, cols];

			for (var r = 0; r < rows; r++)
			{
				var parts = lines[r].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
				for (var c = 0; c < cols; c++)
				{
					grid[r, c] = int.Parse(parts[c]);
				}
			}

			return grid;
        }

		public static double[] FindInputIndex(this double[,] grid, double input)
		{

			var x = -1;
			var y = -1;
			
			var rowLength = grid.GetLength(0);
			var colLength = grid.GetLength(1);

			if (input == 1)
            {
                return [rowLength / 2, colLength / 2];
            }

			for (var row = 0; row < rowLength; row++)
			{
				for (var col = 0; col < colLength; col++)
				{
					if (grid[row, col] == input)
					{
						// found it
						x = row;
						y = col;
						break;
					}
				}
			}

			var coords = new double[2];
			coords[0] = x;
			coords[1] = y;

			return coords;
		}

		public static double FindShortestPath(this double[,] grid, double input)
		{
			var exitIndex = grid.FindInputIndex(1);
			var startIndex = grid.FindInputIndex(input);
			double result = 0;

			if (startIndex[0] == -1 && startIndex[1] == -1)
			{
				return -1;
			}
			if (exitIndex[0] == startIndex[0] && exitIndex[1] == startIndex[1])
			{
				return result;
			}
			if (exitIndex[0] < startIndex[0])
			{
				result += startIndex[0] - exitIndex[0];
			}
			else if (exitIndex[0] > startIndex[0])
			{
				result += exitIndex[0] - startIndex[0];
			}
			if (exitIndex[1] < startIndex[1])
			{
				result += startIndex[1] - exitIndex[1];
			}
			else if (exitIndex[1] > startIndex[1])
			{
				result += exitIndex[1] - startIndex[1];
			}

			return result;
		}
		
		public static int GetAdjacentSum(this int[,] grid, int x, int y)
        {
			var total = 0;
			var boundsX = grid.GetLength(1);
			var boundsY = grid.GetLength(0);
			
			if (x + 1 < boundsX)
				total += grid[y, x + 1];   // right
			if (x + 1 < boundsX && y + 1 < boundsY)
				total += grid[y + 1, x + 1]; // down-right
			if (y + 1 < boundsY)
				total += grid[y + 1, x];   // down
			if (x - 1 >= 0 && y + 1 < boundsY)
				total += grid[y + 1, x - 1]; // down-left
			if (x - 1 >= 0)
				total += grid[y, x - 1];   // left
			if (x - 1 >= 0 && y - 1 >= 0)
				total += grid[y - 1, x - 1]; // up-left
			if (y - 1 >= 0)
				total += grid[y - 1, x];   // up
			if (x + 1 < boundsX && y - 1 >= 0)
				total += grid[y - 1, x + 1]; // up-right
			return total;
        }

		// https://rosettacode.org/wiki/Tokenize_a_string_with_escaping#C.23
		public static IEnumerable<string> Tokenize(this string input, char separator = '\n', char escape = '^')
		{
			if (input == null) yield break;
			var buffer = new StringBuilder();
			var escaping = false;
			foreach (var c in input)
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
			var result = stringBuilder.ToString();
			stringBuilder.Clear();
			return result;
		}
	}
}
