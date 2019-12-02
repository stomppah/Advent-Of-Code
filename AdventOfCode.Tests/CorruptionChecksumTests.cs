using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;
using Xunit;

namespace AdventOfCode.Tests
{
    public class CorruptionChecksumTests
    {
        [Fact]
        public void PartOne()
        {
            string spreadsheet =
@"5 1 9 5
7 5 3
2 4 6 8";
            var result = new Solver().CalculateChecksum(spreadsheet);

            Assert.Equal(18, result);
        }

        [Fact]
        public void PartTwo()
        {
            string spreadsheet =
@"5 9 2 8
9 4 7 3
3 8 6 5";
            var result = new Solver().CalculateChecksumExtended(spreadsheet);

            Assert.Equal(9, result);
        }

    }
}
