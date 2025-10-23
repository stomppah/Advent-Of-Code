using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public static class SpiralGrid
    {
        public static int[,] BuildValues(int n)
        {
            if (n <= 0) throw new ArgumentException("Input must be a positive integer.", nameof(n));

            var values = new int[n];

            for (int i = 0; i < n; i++)
            {
                values[i] = i + 1; // Example logic: fill with sequential numbers starting from 1
            }


            return new int[n,n];
        }
    }
}