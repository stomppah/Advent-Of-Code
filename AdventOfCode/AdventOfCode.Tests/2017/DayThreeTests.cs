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
        [InlineData(TestInputs.DayThree, 2, 1)]
        [InlineData(TestInputs.DayThree, 3, 2)]
        [InlineData(TestInputs.DayThree, 4, 1)]
        [InlineData(TestInputs.DayThree, 5, 2)]
        [InlineData(TestInputs.DayThree, 6, 1)]
        [InlineData(TestInputs.DayThree, 7, 2)]
        [InlineData(TestInputs.DayThree, 8, 1)]
        [InlineData(TestInputs.DayThree, 9, 2)]
        [InlineData(TestInputs.DayThree, 10, 3)]
        [InlineData(TestInputs.DayThree, 11, 2)]
        [InlineData(TestInputs.DayThree, 12, 3)]
        [InlineData(TestInputs.DayThree, 13, 4)]
        [InlineData(TestInputs.DayThree, 23, 2)]
        [InlineData(TestInputs.DayThree, 24, 3)]
        [InlineData(TestInputs.DayThree, 25, 4)]
        [InlineData(1999, 1024, 31)]
        public void FindShortestPath_ShouldReturnCorrectDistance_WhenValidInputProvided(double size, double find, int expected)
        {
            double[,] grid = SpiralGridHelper.Generate(size, _testOutputHelper);
            double result = grid.FindShortestPath(find);
            Assert.Equal(expected, result);
        }

        // --- ❗ EDGE CASE TESTS ---

        [Theory]
        [InlineData("", typeof(ArgumentException))]
        [InlineData(null, typeof(ArgumentNullException))]
        public void ConvertToGrid_ShouldThrowException_WhenInputIsInvalid(string sequence, Type expectedException)
        {
            Assert.Throws(expectedException, () => sequence.ConvertToGrid());
        }

        [Fact]
        public void FindInputIndex_ShouldHandleMissingValueGracefully()
        {
            var grid = SpiralGridHelper.Generate(10, _testOutputHelper);
            var index = grid.FindInputIndex(9999);
            Assert.True(index[0] == -1 && index[1] == -1);
        }

        [Fact]
        public void FindShortestPath_ShouldReturnMinusOne_WhenValueNotFound()
        {
            double[,] grid = SpiralGridHelper.Generate(50, _testOutputHelper);
            double result = grid.FindShortestPath(9999);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ConvertToGrid_ShouldGenerateSingleElementGrid_WhenInputIsMinimal()
        {
            var grid = SpiralGridHelper.Generate(1, _testOutputHelper);
            Assert.Equal(1, grid[grid.GetLength(0) / 2, grid.GetLength(1) / 2]);
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