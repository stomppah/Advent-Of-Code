namespace AdventOfCode.Tests._2017;

using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode._2017;

public class DayFiveTests
{
    private readonly ITestOutputHelper _consoleHelper;
    private readonly Solver _solver = new Solver();
    
    public DayFiveTests(ITestOutputHelper consoleHelper)
    {
        _consoleHelper = consoleHelper;
    }
    
    [Fact]
    public void Test()
    {
        var testInput = new List<int> { 0, 3, 0, 1, -3 };
        double expected = 5;
        
        double result = _solver.FindExit(testInput, 0);
        Assert.Equal(expected, result);
    }
}