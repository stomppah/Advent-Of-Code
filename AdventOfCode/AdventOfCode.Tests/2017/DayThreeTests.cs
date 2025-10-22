using System;
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
        [InlineData(TestInputs.DayThree, 24)]
        public void FindInputIndex_ShouldReturnCorrectCoordinates_WhenValueExists(double size, double find)
        {
            double[,] grid = SpiralGridHelper.Generate(size, _testOutputHelper);
            double[] result = grid.FindInputIndex((int)find);
            Assert.Equal(find, grid[(int)result[0], (int)result[1]]);
        }

        [Theory]
        [InlineData(TestInputs.DayThree, 1, 0)]
        [InlineData(TestInputs.DayThree, 12, 3)]
        [InlineData(TestInputs.DayThree, 23, 2)]
        public void Find_Shortest_Path(int size, int find, int expected)
        {
            double[,] grid = SpiralGridHelper.Generate(size, _testOutputHelper);
            double result = grid.FindShortestPath(find);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Find_Shortest_Path_Extended()
        {
            var testInput = 1024;
            double[,] grid = SpiralGridHelper.Generate(1999, _testOutputHelper);
            double[] indexOfOne = grid.FindInputIndex(testInput);

            _testOutputHelper.WriteLine("Index of " + testInput + ": " + indexOfOne[0] + "," + indexOfOne[1]);
            _testOutputHelper.WriteLine("Value at index: " + grid[(int)indexOfOne[0], (int)indexOfOne[1]]);

            double result = grid.FindShortestPath(testInput);

            Assert.Equal(31, result);
        }

        // --- ⚙️ PERFORMANCE TESTS ---

        [Fact]
        public void SpiralGrid_ShouldGenerateUpTo3MillionValues_AndStayCentered()
        {
            int target = 3_000_000;
            var grid = SpiralGridHelper.Generate(target, _testOutputHelper);
            var centerValue = grid[grid.GetLength(0) / 2, grid.GetLength(1) / 2];
            Assert.Equal(1, centerValue);
        }

    }

    // --- 🔧 HELPER CLASS ---

    internal static class SpiralGridHelper
    {
        public static double[,] Generate(double target, ITestOutputHelper output = null)
        {
            if (target <= 0)
                throw new ArgumentException("Target must be positive.");

            int size = (int)Math.Ceiling(Math.Sqrt(target));
            if (size % 2 == 0) size++; // ensure odd dimensions so 1 stays centred

            double[,] grid = new double[size, size];
            int x = size / 2;
            int y = size / 2;
            grid[y, x] = 1;

            int num = 2, step = 1;

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

            output?.WriteLine($"Spiral grid generated up to {target} ({size}x{size}).");
            return grid;
        }
    }
}