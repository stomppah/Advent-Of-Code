using System.Collections.Generic;

namespace AdventOfCode.Tests._2017;
using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode._2017;

public class DayFourTests
{
    private const string Input = @"aa bb cc dd ee
aa bb cc dd aa
aa bb cc dd aaa";

    private readonly ITestOutputHelper _consoleHelper;

    /// <summary>
    /// --- Day 4: High-Entropy Passphrases ---
    /// A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password.
    /// A passphrase consists of a series of words (lowercase letters) separated by spaces.
    ///
    /// To ensure security, a valid passphrase must contain no duplicate words.
    ///
    /// For example:
    ///
    /// aa bb cc dd ee is valid.
    /// aa bb cc dd aa is not valid - the word aa appears more than once.
    /// aa bb cc dd aaa is valid - aa and aaa count as different words.
    /// The system's full passphrase list is available as your puzzle input.
    /// </summary>
    /// <param name="consoleHelper"></param>
    public DayFourTests(ITestOutputHelper consoleHelper)
    {
        _consoleHelper = consoleHelper;
    }

    /// <summary>
    /// To verify the implementation that determines the number of valid passphrases — where a valid
    /// passphrase contains no duplicate words — you would typically:
    ///
    /// 1. Take a series of passphrases (each as a line or string of words separated by spaces).
    /// 2. Split each passphrase into words.
    /// 3. Check for duplicates.
    /// 4. Count the valid ones.
    /// 5. Compare the result to the expected output to ensure correctness.
    /// </summary>
    [Fact]
    public void ConvertToPassphraseList_ShouldReturnCorrectList_WhenValidInputProvided()
    {
        var expected = new List<string[]>()
        {
            new string[] { "aa", "bb", "cc", "dd", "ee" },
            new string[] { "aa", "bb", "cc", "dd", "aa" },
            new string[] { "aa", "bb", "cc", "dd", "aaa" }
        };
        
        var actual = Input.ConvertToPassphraseList();
        Assert.Equal(expected, actual);
    }
}

public static class PassPhraseHelper
{
    public static List<string[]> PartOne(string input)
    {
        var rowData = input.ConvertToPassphraseList();
        
        
        return rowData;
    }
}
