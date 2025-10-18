using AdventOfCode._2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests._2017
{
    public class DayThreeTests
    {
        [Theory]
        [InlineData(@"17  16  15  14  13
18   5   4   3  12
19   6   1   2  11
20   7   8   9  10
21  22  23  24  25", 1)]
        public void Test_ConvertToGrid_Output(string sequence, double expected)
        {
            var result = sequence.ConvertToGrid();

            Assert.Equal(expected, result[2,2]);
        }

        [Theory]
        [InlineData(@"17  16  15  14  13
18   5   4   3  12
19   6   1   2  11
20   7   8   9  10
21  22  23  24  25", true)]
        public void Find_IndexOf_One(string sequence, bool expected)
        {
            int[,] grid = sequence.ConvertToGrid();
            var result = grid.FindStartIndex();
 
            var found = false;
            if (grid[result[0], result[1]] == 1)
            {
                found = true;
            }

            Assert.Equal(expected, found);
        }

    }
}
