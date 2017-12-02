using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class DayOneTests
    {

        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        public void Test(string sequence, double expected)
        {
            var solver = new Solver();

            var result = solver.SumOfRepeatedNumbers(sequence);

            Assert.AreEqual(expected, result);
        }
    }

    public class Solver
    {
        public double SumOfRepeatedNumbers(string sequence)
        {
            long[] digits = new long[sequence.Length];
            for (int sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
            {
                long digit;
                Int64.TryParse(sequence.Substring(sequenceIndex, 1), out digit);
                digits[sequenceIndex] = digit;
            }
            List<long> matches = new List<long>();
            for (int digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                var nextDigitInSequence = digitIndex < digits.Length - 1 ? digits[digitIndex + 1] : digits[0];
                if (digits[digitIndex] == nextDigitInSequence)
                {
                    matches.Add(digits[digitIndex]);
                }
            }
            return matches.Sum();
        }
    }
}
