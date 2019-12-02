using AdventOfCode._2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests._2017
{
    public class DayOneTests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void Test(string sequence, double expected)
        {
            var solver = new Solver();

            var result = solver.SumOfRepeatedNumbersNextDigit(sequence);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void PartTwo(string sequence, double expected)
        {
            var solver = new Solver();

            var result = solver.SumOfRepeatedNumbersExtended(sequence);

            Assert.Equal(expected, result);
        }
    }
}
