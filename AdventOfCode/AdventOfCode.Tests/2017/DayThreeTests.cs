using AdventOfCode._2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests._2017
{
    public class DayThreeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DayThreeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
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

        [Fact]
        public void Find_Shortest_Path_Extended()
        {
            var testInput = 1024;
            int[,] grid = DayThreeExtended();
            var indexOfOne = grid.FindInputIndex(testInput);

            _testOutputHelper.WriteLine("Index of " + testInput +": " + indexOfOne[0] + "," + indexOfOne[1]);
            _testOutputHelper.WriteLine("Value at index: " + grid[indexOfOne[0], indexOfOne[1]]);

            int result = grid.FindShortestPath(testInput);

            Assert.Equal(31, result);
        }

        public int[,] DayThreeExtended()
        {
            int target = 3000000;
            int size = (int)Math.Ceiling(Math.Sqrt(target));
            if (size % 2 == 0) size++; // ensure odd dimensions so 1 stays centred

            int[,] grid = new int[size, size];
            int x = size / 2;
            int y = size / 2;
            grid[y, x] = 1;

            int num = 2;
            int step = 1;

            while (num <= target)
            {
                // right
                for (int i = 0; i < step && num <= target; i++) grid[y, ++x] = num++;
                // up
                for (int i = 0; i < step && num <= target; i++) grid[--y, x] = num++;

                step++;

                // left
                for (int i = 0; i < step && num <= target; i++) grid[y, --x] = num++;
                // down
                for (int i = 0; i < step && num <= target; i++) grid[++y, x] = num++;

                step++;
            }
            
            _testOutputHelper.WriteLine("Spiral generated up to " + target + " (" + size + "x" + size + ")");
            return grid;
        }
    }
}
