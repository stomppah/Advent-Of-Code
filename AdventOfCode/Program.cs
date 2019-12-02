using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver();

            var answer = solver.SumOfRepeatedNumbersNextDigit(PuzzleInputs.DayOne);
            Console.Write($"Day One (1) Answer: {answer}");
            Console.WriteLine();

            answer = solver.SumOfRepeatedNumbersExtended(PuzzleInputs.DayOne);
            Console.Write($"Day One (2) Answer: {answer}");
            Console.WriteLine();

            answer = solver.CalculateChecksum(PuzzleInputs.DayTwo);
            Console.Write($"Day Two (1) Answer: {answer}");
            Console.WriteLine();

            answer = solver.CalculateChecksumExtended(PuzzleInputs.DayTwo);
            Console.Write($"Day Two (2) Answer: {answer}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
