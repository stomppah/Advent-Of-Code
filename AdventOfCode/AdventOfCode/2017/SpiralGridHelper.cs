using System;

namespace AdventOfCode._2017
{
    // --- 🔧 HELPER CLASS ---
    public static class SpiralGridHelper
    {
        public static double[,] Generate(double target)
        {
            if (target <= 0)
                throw new ArgumentException("Target must be positive.");

            var size = (int)Math.Ceiling(Math.Sqrt(target));
            if (size % 2 == 0) size++; // ensure odd dimensions so 1 stays centred

            var grid = new double[size, size];
            var x = size / 2;
            var y = size / 2;
            grid[y, x] = 1;

            int num = 2, step = 1;

            while (num <= target)
            {
                // right
                for (var i = 0; i < step && num <= target; i++) grid[y, ++x] = num++;
                // up
                for (var i = 0; i < step && num <= target; i++) grid[--y, x] = num++;
                step++;
                // left
                for (var i = 0; i < step && num <= target; i++) grid[y, --x] = num++;
                // down
                for (var i = 0; i < step && num <= target; i++) grid[++y, x] = num++;
                step++;
            }

            return grid;
        }
    }
}