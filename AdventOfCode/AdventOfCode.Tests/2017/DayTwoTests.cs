using AdventOfCode._2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests._2017
{
    public class DayTwoTests
    {
        [Fact]
        public void PartOne()
        {
            var spreadsheet =
@"5 1 9 5
7 5 3
2 4 6 8";
            var result = new Solver().CalculateChecksum(spreadsheet);

            Assert.Equal(18, result);
        }

        [Fact]
        public void PartTwo()
        {
            var spreadsheet =
@"5 9 2 8
9 4 7 3
3 8 6 5";
            var result = new Solver().CalculateChecksumExtended(spreadsheet);

            Assert.Equal(9, result);
        }

    }
}
