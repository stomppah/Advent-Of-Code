using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode._2017;

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
            var grid = SpiralGridHelper.Generate(size, _testOutputHelper);
            var result = grid.FindInputIndex((int)find);
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
            var grid = SpiralGridHelper.Generate(size, _testOutputHelper);
            var result = grid.FindShortestPath(find);
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
            var grid = SpiralGridHelper.Generate(50, _testOutputHelper);
            var result = grid.FindShortestPath(9999);
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
            var target = 3_000_000;
            var grid = SpiralGridHelper.Generate(target, _testOutputHelper);
            var centerValue = grid[grid.GetLength(0) / 2, grid.GetLength(1) / 2];
            Assert.Equal(1, centerValue);
        }

        // --- PART TWO TESTS ---

        [Fact]
        public void BuildValues_FirstTwentyThreeMatchKnownSequence()
        {
            // Known prefix from the problem description.
            var expected = new[,]
            {
                {147, 142, 133, 122, 59 },
                {304,  5,    4,   2, 57 },
                {330,  10,   1,   1, 54 },
                {351,  11,  23,  25, 26 },
                {362, 747, 806, 880, 931 }
            };
            var actual = SpiralGrid.BuildValues(expected.Length);
            Assert.Equal(expected, actual);
        }
    }
}