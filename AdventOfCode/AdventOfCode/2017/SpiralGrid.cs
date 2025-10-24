using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public static class SpiralGrid
    {
        public static int[,] BuildValues(int length)
        {
            if (length <= 0) throw new ArgumentException("Input must be a positive integer.", nameof(length));

            // Build grid up to value n
            var size = (int)Math.Ceiling(Math.Sqrt(length));
            if (size % 2 == 0) size++; // ensure odd dimensions so 1 stays centred

            var grid = new int[size, size];
            var x = size / 2;
            var y = size / 2;
            grid[y, x] = 1;

            int num = 2, step = 1;

            while (num <= length)
            {
                // right
                for (var i = 0; i < step && num <= length; i++)
                {
                    grid[y, ++x] = grid.GetAdjacentSum(x, y);  
                }
                // up
                for (var i = 0; i < step && num <= length; i++)
                {

                    grid[--y, x] = num++; 
                }
                step++;
                // left
                for (var i = 0; i < step && num <= length; i++)
                {
                    grid[y, --x] = num++; 
                }
                // down
                for (var i = 0; i < step && num <= length; i++)
                {
                    grid[++y, x] = num++; 
                }
                step++;
            }

            return grid;
        }
    }
}