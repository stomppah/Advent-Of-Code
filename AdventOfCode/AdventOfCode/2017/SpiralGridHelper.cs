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

            int size = (int)Math.Ceiling(Math.Sqrt(target));
            if (size % 2 == 0) size++; // ensure odd dimensions so 1 stays centred

            double[,] grid = new double[size, size];
            int x = size / 2;
            int y = size / 2;
            grid[y, x] = 1;

            int num = 2, step = 1;

            while (num <= target)
            {
                // right
                for (int i = 0; i < step && num <= target; i++) grid[y, ++x] = num++;
                // up
                for (int i = 0; i < step && num <= target; i++) grid[--y, x] = num++;
                step++;
                // left
                for (int i = 0; i < step && num <= target; i++) grid[y, --x] = num++;
                // down
                for (int i = 0; i < step && num <= target; i++) grid[++y, x] = num++;
                step++;
            }

            return grid;
        }
    }
}