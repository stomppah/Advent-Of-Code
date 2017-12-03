using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
    public static class StringExtensions
    {

        public static long[] ConvertToLongArray(this string sequence)
        {
            long[] digits = new long[sequence.Length];
            for (int sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
            {
                long digit;
                Int64.TryParse(sequence.Substring(sequenceIndex, 1), out digit);
                digits[sequenceIndex] = digit;
            }
            return digits;
        }
    }
}
