using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class DayOneTests
    {

        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void Test(string sequence, double expected)
        {
            var solver = new Solver();

            var result = solver.SumOfRepeatedNumbersNextDigit(sequence);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        public void PartTwo(string sequence, double expected)
        { 
            var solver = new Solver();

            var result = solver.SumOfRepeatedNumbersExtended(sequence);

            Assert.AreEqual(expected, result);
        }
    }
}
