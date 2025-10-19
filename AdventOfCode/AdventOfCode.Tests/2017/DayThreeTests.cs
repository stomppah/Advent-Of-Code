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
        [InlineData(TestInputs.DayThree, 1)]
        public void Test_ConvertToGrid_Output(string sequence, double expected)
        {
            var result = sequence.ConvertToGrid();

            Assert.Equal(expected, result[2,2]);
        }

        [Theory]
        [InlineData(TestInputs.DayThree, 1, true)]
        [InlineData(TestInputs.DayThree, 24, true)]
        public void Find_IndexOf(string sequence, int find, bool expected)
        {
            int[,] grid = sequence.ConvertToGrid();
            var result = grid.FindInputIndex(find);

            var found = false;
            if (grid[result[0], result[1]] == find)
            {
                found = true;
            }

            Assert.Equal(expected, found);
        }

        [Theory]
        [InlineData(TestInputs.DayThree, 1, 0)]
        [InlineData(TestInputs.DayThree, 12, 3)]
        [InlineData(TestInputs.DayThree, 23, 2)]
        public void Find_Shortest_Path(string sequence, int find, int expected)
        {
            int[,] grid = sequence.ConvertToGrid();
            int result = grid.FindShortestPath(find);

            Assert.Equal(expected, result);
        }

    }
}
